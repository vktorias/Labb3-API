using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string Website { get; set; }
        [ForeignKey("Interests")]
        public int InterestId { get; set; }
        public Interest? Interests { get; set; }

    }
}
