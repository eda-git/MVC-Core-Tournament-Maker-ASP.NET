using Microsoft.EntityFrameworkCore;
using tourneybracket.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
namespace tourneybracket.Data
{
    public class BracketContext : DbContext
    {
        public BracketContext(DbContextOptions<BracketContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<Round> Rounds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
           modelBuilder.Entity<Match>().ToTable("Match");

            //Unable to determine the relationship represented by navigation property 'Match.TeamA' of type 'Team'. 
            modelBuilder.Entity<Bracket>()
                .ToTable("Bracket")
                .HasKey(t => new { t.id });

           
            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamA)
                .WithMany(p => p.Matches)
                .HasForeignKey(m => m.TeamAID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Match>()
                    .HasOne(m => m.TeamB)
                    .WithMany(p => p.OppMatches)
                    .HasForeignKey(m => m.TeamBID)
                    .OnDelete(DeleteBehavior.Restrict);

        }
     
    }
}
