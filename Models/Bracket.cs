using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tourneybracket.Models
{
    public class Bracket
    {
        
        [Key]
        public int id { get; set; }
        [Required]
        public string BracketName { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int TotalRounds { get; set; }
        public List<Round> Rounds { get; set; }
    }
}
