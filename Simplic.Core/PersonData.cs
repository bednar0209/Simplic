using System.ComponentModel.DataAnnotations;

namespace Simplic.Core
{
    public class PersonData
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        [Required]
        public string Address { get; set; }

    }
}