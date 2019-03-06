using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ViewModels
{
    public class Item: CommonEntity
    {
        [Key]
        public Int64 Item_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Item Code")]        
        [StringLength(10)]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Please Enter Item Name")]
        [StringLength(100)]
        public string ItemName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
   

    }

}
