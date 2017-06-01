using Newtonsoft.Json.Linq;
using SuggestionBoxAPI.Core.Models;
using SuggestionBoxAPI.Core.Respositories;
using SuggestionBoxAPI.Persistence.Repositories;
using SuggestionBoxAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SuggestionBoxAPI.Controllers
{
    public class TypeSuggestionsController : ApiController
    {
        private ITypeSuggestionRepository repository;

        private string[] AllowedFileExtensions = { ".jpg", ".gif", ".png" };

        private const string BaseUri = "http://localhost:60024/";
        private const string ImagesTypeSuggestionPath = "www/images/TypeSuggestions/";
        private const string ImagesTypeSuggestionUri = BaseUri + ImagesTypeSuggestionPath;

        public TypeSuggestionsController()
        {
            repository = new TypeSuggestionRepository();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            TypeSuggestion typeOfSuggestion = repository.Get(id);

            if (typeOfSuggestion == null)
            {
                return NotFound();
            }

            return Ok(typeOfSuggestion);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<TypeSuggestion> typeSuggestions = repository.GetAll().ToList();
            return Ok(typeSuggestions);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] TypeSuggestion typeOfSuggestion)
        {
            TypeSuggestion typeSuggestionInserted = repository.Add(typeOfSuggestion);

            Uri typeSuggestionLocation = new Uri(Request.RequestUri, typeOfSuggestion.Id.ToString());
            return Created(typeSuggestionLocation, typeSuggestionInserted);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] TypeSuggestion typeOfSuggestion)
        {
            typeOfSuggestion.Id = id;

            repository.Update(typeOfSuggestion);
            return Ok(typeOfSuggestion);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            TypeSuggestion typeOfSyggestion = new TypeSuggestion { Id = id };
            repository.Remove(typeOfSyggestion);
        }

        [Route("api/typesuggestions/thumbnail")]
        [HttpPost]
        public IHttpActionResult UploadThumbnail()
        {
            try
            {
                HttpRequest httpRequest = HttpContext.Current.Request;
                HttpFileCollection filesUploaded = httpRequest.Files;

                if (filesUploaded.Count <= 0)
                {
                    return BadRequest("You have not uploaded any files!");
                }

                HttpPostedFile fileToSave = filesUploaded[0];
                HttpFileUploader httpFileUploader = new HttpFileUploader(AllowedFileExtensions);

                string folderPath = HttpContext.Current.Server.MapPath("~/" + ImagesTypeSuggestionPath);
                string fileName = DateTime.Now.Ticks + HttpFileUploader.GetFileExtensionWithDot(fileToSave.FileName);

                httpFileUploader.saveFile(fileToSave, folderPath, fileName);

                Uri baseUri = new Uri(ImagesTypeSuggestionUri);
                Uri imageLocation = new Uri(baseUri, fileName);

                string imgLocationJson = "{ \"imageUri\": \"" + imageLocation + "\"}";

                return Created(imageLocation, JObject.Parse(imgLocationJson));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
