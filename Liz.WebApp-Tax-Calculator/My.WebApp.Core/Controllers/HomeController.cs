using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My.Web.App.RabbitBroker.Publisher;
using My.WebApp.Core.Models;
using My.WebApp.Core.Models.ViewModels;
using My.WebApp.Core.Repository.Sql;
using My.WebApp.Core.Service.TaxCalculation;

namespace My.WebApp.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISqlRepository _sqlRepository;
        private readonly ITaxCalculation _taxCalculation;
        private readonly IPublisher _publisher;

        private readonly bool doRabbitPublish = true;

        public HomeController(ISqlRepository sqlRepository,
            ITaxCalculation taxCalculation,
            IPublisher publisher)
        {
            _sqlRepository = sqlRepository;
            _taxCalculation = taxCalculation;
            _publisher = publisher;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var postalCodes = _sqlRepository.GetPostalCodes();

            ViewBag.PostalCodes = new SelectList(postalCodes, "PostalCode", "PostalCode");

            return View();
        }

        [HttpPost]
        public IActionResult Index(TaxViewModel taxViewModel)
        {
            if (ModelState.IsValid)
            {
                var taxCalculatedResponse = _taxCalculation.CalculationIncomeTax(taxViewModel);

                if (taxCalculatedResponse != null)
                {
                    var taxCalculationModel = new Models.DbModel.TaxCalculation
                    {
                        AnnualIncome = (decimal)taxViewModel.AnnualIncome,
                        Name = taxViewModel.Name.ToLower(),
                        TaxCalculated = (decimal)taxCalculatedResponse.CalculatedTax,
                        CalculationType = taxCalculatedResponse.CalculationType.ToLower(),
                        DateCreated = DateTime.Now
                    };

                    var hasSaved = _sqlRepository.Save(taxCalculationModel);

                    //this is just to send a message to rabbitMQ
                    //disable this if you do not have a local instance of rabbit installed :)
                    if (doRabbitPublish)
                    {
                        _publisher.PublishMessage(taxCalculationModel);
                    }
                }
            }

            return RedirectToAction("Index", "Data");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
