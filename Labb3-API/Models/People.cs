using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }
        public int PhoneNumber { get; set; }

    }
}
