using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class PeopleInterest
    {
        [Key]
        public int PeopleInterestId { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }

    }
}
