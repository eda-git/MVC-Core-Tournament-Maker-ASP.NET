using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourneybracket.Models
{
    
    public class Match 
    {
        
        [Required]
        public int MatchID { get; set; }
        public int MatchNumber { get; set; }
        [ForeignKey("Team")]
        public int? TeamAID { get; set; }
        [ForeignKey("Team")]
        public int? TeamBID { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public int? TeamAScore { get; set; }
        public int? TeamBScore { get; set; }
        public int? WinnerID { get; set; }
        [ForeignKey("Bracket")]
        public int BracketID { get; set; }
        public Bracket Bracket { get; set; }
        public int RoundNumber { get; set; }
    }
}
