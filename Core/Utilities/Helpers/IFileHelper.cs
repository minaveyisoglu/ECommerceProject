using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string Add(IFormFile formFile, string root);
        void Delete(string filePath);
        string Update(IFormFile formFile, string root, string filePath);

    }
}
