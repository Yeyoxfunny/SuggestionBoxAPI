using SuggestionBoxAPI.Core.Models;
using SuggestionBoxAPI.Core.Respositories;
using SuggestionBoxAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuggestionBoxAPI.Controllers
{
    public class SuggestionsController : ApiController
    {
        private ISuggestionRepository repository;

        public SuggestionsController()
        {
            this.repository = new SuggestionRepository();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Suggestion suggestion = repository.Get(id);

            if(suggestion == null)
            {
                return NotFound();
            }

            return Ok(suggestion);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Suggestion> suggestions = repository.GetAll().ToList();
            return Ok(suggestions);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Suggestion suggestion)
        {
            Suggestion sug = repository.Add(suggestion);
            Uri uri = new Uri(Request.RequestUri, sug.Id.ToString());
            return Created(uri, sug);
        }

        [HttpPut]
        public IHttpActionResult Put(int id,[FromBody] Suggestion suggestion)
        {
            suggestion.Id = id;
            repository.Update(suggestion);
            return Ok();
        }
    }
}
