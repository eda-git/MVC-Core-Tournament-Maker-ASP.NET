using tourneybracket.Models;
using System;
using System.Linq;

namespace tourneybracket.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BracketContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Brackets.Any())
            {
                return;   // DB has been seeded
            }
            //id, BracketName, CreatedAt, TotalRounds
            /*var brackets = new Bracket[]
            {
            new Bracket{id=1,BracketName="Test Tournament 1",CreatedAt=DateTime.Now, TotalRounds = 2},
            };
            foreach (Bracket s in brackets)
            {
                context.Brackets.Add(s);
            }*/

            context.SaveChanges();
        }
    }
}