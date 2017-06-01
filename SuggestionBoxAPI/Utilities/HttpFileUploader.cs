using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SuggestionBoxAPI.Utilities
{
    public class HttpFileUploader
    {
        private int _MaxContentLength;
        private string[] _AllowedFileExtensions;

        public HttpFileUploader(string[] allowedFileExtensions)
        {
            this._AllowedFileExtensions = allowedFileExtensions;
            this._MaxContentLength = 0;
        }

        public HttpFileUploader(int maxContentLength, string[] allowedFileExtensions)
        {
            this._MaxContentLength = maxContentLength;
            this._AllowedFileExtensions = allowedFileExtensions;
        }

        public void saveFile(HttpPostedFile postedFile, string folderPath, string fileName)
        {
            string extension = GetFileExtensionWithDot(fileName);

            if (!isAllowedFileExtension(extension))
            {
                throw new HttpFileUploaderException("Please Upload image of type " + String.Join(",", _AllowedFileExtensions));
            }

            if (_MaxContentLength > 0 && postedFile.ContentLength > _MaxContentLength)
            {
                //TODO Add unit digital information (MB, GB, TB)
                throw new HttpFileUploaderException("Please Upload a file upto " + _MaxContentLength);
            }

            string fileSavePath = Path.Combine(folderPath, fileName);
            postedFile.SaveAs(fileSavePath);
        }

        private bool isAllowedFileExtension(string extension)
        {
            return _AllowedFileExtensions.Contains(extension);
        }

        public static string GetFileExtensionWithDot(string fullName)
        {
            string extension = fullName.Substring(fullName.LastIndexOf("."));
            return extension.ToLower();
        }
    }
}