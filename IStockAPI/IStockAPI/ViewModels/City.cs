using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    [Table("City")]
    public class City:CommonEntity
    {
        [Key]
        public Int64 City_Id { get; set; }

        [Required(ErrorMessage = "Please Enter City Code")]        
        [StringLength(10)]
        public string City_Code { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [StringLength(100)]
        public string City_Name { get; set; }

       
    }

}
