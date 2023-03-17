using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace database_mvc.Models
{
    [Table("YProductCategory")]
    public class ProductCat
    {
        public int Id { get; set; }
        public string Pname { get; set; }
        
    }
}
