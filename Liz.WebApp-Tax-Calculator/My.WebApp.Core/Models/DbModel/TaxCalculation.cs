using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Models.DbModel
{
    public class TaxCalculation
    {
        [Key]
        [Display(Name = "ID")]
        public int TaxCalculationId {get;set;}
        [Display(Name = "Created Date & Time")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        //[Display(Name = "Tax Calculated")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal TaxCalculated { get; set; }
        //[Display(Name = "Annual Income")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal AnnualIncome { get; set; }
        [Display(Name = "Type")]
        public string CalculationType { get; set; }
    }
}
