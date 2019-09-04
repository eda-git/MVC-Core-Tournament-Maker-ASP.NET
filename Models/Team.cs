using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourneybracket.Models
{
    public class Team
    {
        public int id { get; set; }
        [Required]
        public string TeamName { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<Match> OppMatches { get; set; }
        [ForeignKey("Bracket")]
        public int BracketID { get; set; }
    }
}
