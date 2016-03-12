using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class Product批次更新ViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1,99)]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Range(1, 99)]
        public Nullable<decimal> Stock { get; set; }
    
    }
}