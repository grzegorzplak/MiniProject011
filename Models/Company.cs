using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject011.Models
{
    [Table("MiniProject011_Companies")]
    public class Company
    {
        public int Id { get; set; }
        [DisplayName("Company name")]
        public string CompanyName { get; set; }
        [DisplayName("Address")]
        public string AddressLine { get; set; }
        public string City { get; set; }
        [DisplayName("Postal code")]
        public string? PostalCode { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
