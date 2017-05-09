using SuggestionBoxAPI.Core.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SuggestionBoxAPI.Core.Models;

namespace SuggestionBoxAPI.Persistence.Repositories
{
    public class TypeSuggestionRepository : ITypeSuggestionRepository
    {
        private SuggestionBoxContext context;

        public TypeSuggestionRepository()
        {
            context = new SuggestionBoxContext();
        }

        public TypeSuggestion Get(int id)
        {
            return context.TypeOfSuggestions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TypeSuggestion> GetAll()
        {
            return context.TypeOfSuggestions.ToList();
        }

        public TypeSuggestion Add(TypeSuggestion typeOfSuggestion)
        {
            context.TypeOfSuggestions.Add(typeOfSuggestion);
            context.SaveChanges();

            return typeOfSuggestion;
        }

        public void Update(TypeSuggestion typeOfSuggestion)
        {
            TypeSuggestion entity = context.TypeOfSuggestions.Find(typeOfSuggestion.Id);
            context.Entry(entity).CurrentValues.SetValues(typeOfSuggestion);
            context.SaveChanges();
        }

        public void Remove(TypeSuggestion typeOfSuggestion)
        {
            context.TypeOfSuggestions.Attach(typeOfSuggestion);
            context.TypeOfSuggestions.Remove(typeOfSuggestion);
            context.SaveChanges();
        }
    }
}