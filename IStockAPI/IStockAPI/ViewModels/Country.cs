using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    [Table("Country")]
    public class Country:CommonEntity
    {
        [Key]
        public Int64 Country_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Country Code")]        
        [StringLength(10)]
        public string Country_Code { get; set; }

        [Required(ErrorMessage = "Please Enter Country Name")]
        [StringLength(100)]
        public string Country_Name { get; set; }


    }

}
