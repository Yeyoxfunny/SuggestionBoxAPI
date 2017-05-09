using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestionBoxAPI.Core.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int IdTypeSuggestion { get; set; }
        public virtual TypeSuggestion TypeOfSuggestion { get; set; }

    }
}