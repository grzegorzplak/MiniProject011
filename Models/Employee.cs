using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject011.Models
{
    [Table("MiniProject011_Employees")]
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
    }
}
