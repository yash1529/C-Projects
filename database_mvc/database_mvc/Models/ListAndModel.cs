using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace database_mvc.Models
{
    
    public class ListAndModel
    {
        public int PId { get; set; }
        [DisplayName("Name of the Product : ")]
        [Required(ErrorMessage ="This field is required")]
        public string Pname { get; set; }
        [DisplayName("Price : ")]
        [Required(ErrorMessage = "This field is required")]
        public int Pprice { get; set; }
        [DisplayName("Color : ")]
        [Required(ErrorMessage = "This field is required")]
        public string PColor { get; set; }
        public int Pcategory { get; set; }

        public List<ProductCat> Categories { get; set; }
    }
}
