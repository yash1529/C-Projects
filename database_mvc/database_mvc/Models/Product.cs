using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace database_mvc.Models
{
    [Table("YProducts")]
    public class Product
    {
        /*
        Products
            Id
            Name
            Price
            Color
            ProductCategory
         */
        [Key]
        public int PId { get; set; }
    
        public string Pname { get; set; }
        public int Pprice { get; set; }
        public string PColor { get; set; }
        [ForeignKey("YProductCategory")]
        public int Pcategory { get; set; }
        
    }
}
