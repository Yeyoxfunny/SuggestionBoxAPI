using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SuggestionBoxAPI.Controllers
{

    public class FileController : ApiController
    {
        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };

        [HttpPost]
        public IHttpActionResult PostUploadImage()
        {
            HttpRequest httpRequest = HttpContext.Current.Request;

            var postedFile = httpRequest.Files.Count > 0? httpRequest.Files["image"] : null;

            if (postedFile == null || postedFile.ContentLength < 0)
            {
                return BadRequest("File must not be empty");
            }

            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("."));
            var extension = ext.ToLower();

            if (!AllowedFileExtensions.Contains(extension))
            {
                string message = "Please Upload image of type .jpg,.gif,.png.";
                return BadRequest(message);
            }

           
            string fileMapPath = HttpContext.Current.Server.MapPath("~/UploadedFiles/images/TypeSuggestions");
            string fileSavePath = Path.Combine(fileMapPath, postedFile.FileName); 

            postedFile.SaveAs(fileSavePath);

            return Created(fileMapPath, fileMapPath);
        }
    }
}
