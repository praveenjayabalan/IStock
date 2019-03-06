using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    [Table("Buyer")]
    public class Buyer:CommonEntity
    {
        [Key]
        public long Buyer_id { get; set; }
        public long? Organization_id { get; set; }
        [Required(ErrorMessage = "Please Enter Buyer Code")]
        [StringLength(10)]
        public string Buyer_Code { get; set; }
        [Required(ErrorMessage = "Please Enter Buyer Name")]
        [StringLength(100)]
        public string Buyer_Name { get; set; }
        public string Contact_Person { get; set; }
        public string Phone_No { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? City_id { get; set; }
        public long? State_id { get; set; }
        public long? Country_id { get; set; }
        public string Postal_code { get; set; }
        public string GSTIN_UIN { get; set; }
        public string CIN { get; set; }
        public string Fax_no { get; set; }
        public string PAN { get; set; }
        
    }

}
