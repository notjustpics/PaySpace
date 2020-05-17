using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Models.DbModel
{
    public class LupPostalCode
    {
        [Key]
        public int PostalCodeId { get; set; }
        public string PostalCode { get; set; }
        [ForeignKey("TaxTypeId")]
        public int TaxTypeId { get; set; }
        public LupCalculationType LupCalculationType { get; set; }
    }
}
