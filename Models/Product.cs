using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailo.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
		[MaxLength(15)]
		public string Name { get; set; }
		[MaxLength(50)]
		public string? Description { get; set; }
		[MaxLength(50)]
		public string Image {  get; set; }
        public DateTime AdditionDate { get; set; } = DateTime.Now;

        [Range(1,5)]
        public decimal Rating { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Price { get; set; }

        public ICollection<Review>? reviews { get; set; }
		public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<Wishlist>? wishlists { get; set; }


    }
}
