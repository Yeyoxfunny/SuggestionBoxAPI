using SuggestionBoxAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestionBoxAPI.Core.Respositories
{
    public interface ISuggestionRepository
    {
        Suggestion Get(int id);
        IEnumerable<Suggestion> GetAll();
        Suggestion Add(Suggestion suggestion);
        void Update(Suggestion suggestion);
    }
}