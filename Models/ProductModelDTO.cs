using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Models
{
    public class ProductModelDTO

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
        public string PriceString { get; set; }
        public string ShortInfo { get; set; }
        public decimal Tax { get; set; }
        // then here we will create constructor with original properties;
        public ProductModelDTO(int id, string name, decimal price, string info)

        {
            Id = id;
            Name = name;
            Price = price;
            Info = info;
            PriceString = string.Format("{0:C}", price);
            ShortInfo = info.Length <= 25 ? info : info.Substring(0, 25);
            Tax = price * 0.08M;



        }
        // alternetive way its better to just pass one thing as prameter
        public ProductModelDTO(ProductModel product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Info = product.Info;
            PriceString = string.Format("{0:C}", product.Price);
            ShortInfo = product.Info.Length <= 25 ? product.Info : product.Info.Substring(0, 25);
            Tax = product.Price * 0.08M;



        }



    }
}
