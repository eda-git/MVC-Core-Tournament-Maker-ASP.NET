using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace tourneybracket.Models
{
    // This Class is not used
    public class Round
    {
        [Key]
        public int id { get; set; }
        public int BracketID { get; set; }
        [Required]
        public Bracket Bracket { get; set; }
        [Required]
        public int RoundNumber { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}
