using System.ComponentModel.DataAnnotations;
using Mailo.Data.Enums;

namespace Mailo.Models
{
    public class Employee
	{
		[Key]
		public int ID { get; set; }
		[MaxLength(20)]
		public string FName { get; set; }
		[MaxLength(20)]
		public string LName { get; set; }
        public string FullName { get; private set; }

        [MaxLength(12)]
		public string PhoneNumber { get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(20)]
		public string Password { get; set; }
		[EnumDataType(typeof(Gender))]
		public Gender Gender { get; set; }
		public DateTime HiringDate { get; set; }
		public ICollection<Order>? orders { get; set; }
	}
}
