using SuggestionBoxAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionBoxAPI.Core.Respositories
{
    interface ITypeSuggestionRepository
    {
        TypeSuggestion Get(int id);
        IEnumerable<TypeSuggestion> GetAll();
        TypeSuggestion Add(TypeSuggestion typeOfSuggestion);
        void Update(TypeSuggestion typeOfSuggestion);
        void Remove(TypeSuggestion typeOfSuggestion);
    }
}
