
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    [Table("Company")]
    public class Company : CommonEntity
    {
        [Key]
        public long Company_Id { get; set; }
        public long? User_id { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        [StringLength(100)]
        public string Company_Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string GSTIN_UIN { get; set; }
        public string CIN { get; set; }
        public string Contact_Person { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? City_id { get; set; }
        public long? State_id { get; set; }
        public long? Country_id { get; set; }
        public string Pincode { get; set; }
        public string Fax_no { get; set; }
        public string PAN { get; set; }
        public string Service_Tax_No { get; set; }
        public string State_code { get; set; }
        public string Website { get; set; }
    
    }
}
