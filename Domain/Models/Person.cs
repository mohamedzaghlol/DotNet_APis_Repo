using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Grad { get; set; }
    }
}
