using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mailo.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(100)]
		public string Message { get; set; }
        public ICollection<EmployeeContact> employeeContacts { get; set; }
    }
}
