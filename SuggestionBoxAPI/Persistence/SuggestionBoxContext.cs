using SuggestionBoxAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuggestionBoxAPI.Persistence
{
    public class SuggestionBoxContext : DbContext
    {
        public DbSet<TypeSuggestion> TypeOfSuggestions { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<SuggestionState> SuggestionState { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suggestion>().Property(x => x.Description).HasColumnType("Text");
            modelBuilder.Entity<Suggestion>().Property(x => x.CreationDate).HasColumnType("Date");
        }
    }
}