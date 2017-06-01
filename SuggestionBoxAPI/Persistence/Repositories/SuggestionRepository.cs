using SuggestionBoxAPI.Core.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuggestionBoxAPI.Core.Models;

namespace SuggestionBoxAPI.Persistence.Repositories
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private SuggestionBoxContext context;

        public SuggestionRepository()
        {
            this.context = new SuggestionBoxContext();
        }

        public Suggestion Add(Suggestion suggestion)
        {
            context.Suggestions.Add(suggestion);
            context.SaveChanges();

            return suggestion;
        }

        public Suggestion Get(int id)
        {
            return context.Suggestions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Suggestion> GetAll()
        {
            return context.Suggestions.ToList();
        }

        public void Update(Suggestion suggestion)
        {
            Suggestion entity = context.Suggestions.Find(suggestion.Id);
            context.Entry(entity).CurrentValues.SetValues(suggestion);
            context.SaveChanges();
        }
    }
}