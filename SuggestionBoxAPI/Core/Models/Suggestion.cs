using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestionBoxAPI.Core.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }


        public int StateId { get; set; }
        public virtual SuggestionState State { get; set; }

        public int TypeSuggestionId { get; set; }
        public virtual TypeSuggestion TypeOfSuggestion { get; set; }

    }
}