using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Models.DbModel
{
    public class LupCalculationType
    {
        [Key]
        public int TaxTypeId { get; set; }
        public string TaxTypeName { get; set; }
        public ICollection<LupPostalCode> LupPostalCodes { get; set; }
    }
}
