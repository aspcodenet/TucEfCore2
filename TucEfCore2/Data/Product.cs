using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TucEfCore2.Data
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
