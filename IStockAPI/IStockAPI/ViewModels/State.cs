using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    [Table("State")]
    public class State:CommonEntity
    {
        [Key]
        public Int64 State_Id { get; set; }

        [Required(ErrorMessage = "Please Enter State Code")]        
        [StringLength(10)]
        public string State_Code { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        [StringLength(100)]
        public string State_Name { get; set; }


    }

}
