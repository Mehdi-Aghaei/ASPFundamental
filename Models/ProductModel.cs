﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Models
{
    public class ProductModel
    {
        // we use required attributes for data control and being more spesific
        public int Id { get; set; }
       // [Required]
       // [StringLength(20, MinimumLength = 4)]
        [DisplayName("Enter full name")]
        public string Name { get; set; }
        //[DataType(DataType.Currency)]
        //[Range(0, 100)]
        public decimal Price { get; set; }

       // [StringLength(30,MinimumLength =4)]
        public string Info { get; set; }
    }

}
