using System.ComponentModel.DataAnnotations;

namespace ShoppingPortal.Models
{


    //Data Annotations
    //Validation Attributes
    //Required
    //Range
    //StringLength
    //RegularExpression
    //Compare
    //DataType
    //Display
    //DisplayName

    //Step 1: Create a Model Class
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(5000,650000)]
        public decimal Price { get; set; }
    }
}
