using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IStockAPI.ItemViewModels
{
    public class ItemViewModel
    {
    	[Required]    
    	[UniqueValue]
        public string ItemCode { get; set; }

        [Required]        
        public string ItemName { get; set; }

        [Required]
        public string Description { get; set; }
    }

	public class UniqueValue : ValidationAttribute
	{
	    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	    {
	        //Get a list of all properties that are marked with [UniqueAnswersOnly]
	        var props = validationContext.ObjectInstance.GetType().GetProperties().Where(
	            prop => Attribute.IsDefined(prop, typeof(UniqueAnswersOnly)));

	        var values = new HashSet<string>();

	        //Read the values of all other properties
	        foreach(var prop in props)
	        {
	            var pValue = (string)prop.GetValue(validationContext.ObjectInstance);
	            if (prop.Name!=validationContext.MemberName && !values.Contains(pValue))
	            {
	                values.Add(pValue);
	            }
	        }

	        if (values.Contains(value))
	        {
	            return new ValidationResult("Duplicate answer", new[] { validationContext.MemberName });
	        }
	        return null;
	    }
	}

}
