using SuggestionBoxAPI.Core.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SuggestionBoxAPI.Core.Models;

namespace SuggestionBoxAPI.Persistence.Repositories
{
    public class TypeSuggestionRepository : ITypeSuggestionRepository
    {

        public TypeSuggestion Get(int id)
        {
            using (var context = new SuggestionBoxContext()) {
                return context.TypeOfSuggestions.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<TypeSuggestion> GetAll()
        {
            using (var context = new SuggestionBoxContext())
            {
                return context.TypeOfSuggestions.ToList();
            }
        }

        public TypeSuggestion Add(TypeSuggestion typeOfSuggestion)
        {
            using (var context = new SuggestionBoxContext())
            {
                context.TypeOfSuggestions.Add(typeOfSuggestion);
                context.SaveChanges();

                return typeOfSuggestion;
            }
        }

        public void Update(TypeSuggestion typeOfSuggestion)
        {
            using (var context = new SuggestionBoxContext())
            {
                TypeSuggestion entity = context.TypeOfSuggestions.Find(typeOfSuggestion.Id);
                context.Entry(entity).CurrentValues.SetValues(typeOfSuggestion);
                context.SaveChanges();
            }
        }

        public void Remove(TypeSuggestion typeOfSuggestion)
        {
            using (var context = new SuggestionBoxContext())
            {
                context.TypeOfSuggestions.Attach(typeOfSuggestion);
                context.TypeOfSuggestions.Remove(typeOfSuggestion);
                context.SaveChanges();
            }
        }
    }
}
