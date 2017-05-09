using SuggestionBoxAPI.Core.Models;
using SuggestionBoxAPI.Core.Respositories;
using SuggestionBoxAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SuggestionBoxAPI.Controllers
{
    public class TypeSuggestionsController : ApiController
    {
        private ITypeSuggestionRepository repository;

        public TypeSuggestionsController()
        {
            repository = new TypeSuggestionRepository();
        }

        public IHttpActionResult Get(int id)
        {
            TypeSuggestion typeOfSuggestion = repository.Get(id);

            if (typeOfSuggestion == null)
            {
                return NotFound();
            }

            return Ok(typeOfSuggestion);
        }

        public IHttpActionResult GetAll()
        {
            List<TypeSuggestion> typeSuggestions = repository.GetAll().ToList();
            return Ok(typeSuggestions);
        }

        public IHttpActionResult Post([FromBody] TypeSuggestion typeOfSuggestion)
        {
            TypeSuggestion typeSuggestionInserted = repository.Add(typeOfSuggestion);

            Uri typeSuggestionLocation = new Uri(Request.RequestUri, typeOfSuggestion.Id.ToString());
            return Created(typeSuggestionLocation, typeSuggestionInserted);
        }

        public IHttpActionResult Update(int id, [FromBody] TypeSuggestion typeOfSuggestion)
        {
            typeOfSuggestion.Id = id;

            repository.Update(typeOfSuggestion);
            return Ok();
        }

        public void Delete(int id)
        {
            TypeSuggestion typeOfSyggestion = new TypeSuggestion { Id = id };
            repository.Remove(typeOfSyggestion);
        }
    }
}
