using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    public class Item
    {
        [Key]
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "Please Enter ItemCode")]
        [EmailAddress]
        [StringLength(10)]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Please Enter ItemName")]
        [StringLength(100)]
        public string ItemName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

}
