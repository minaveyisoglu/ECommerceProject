using Microsoft.AspNetCore.Http;
using System;
using System.IO;


namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile formFile, string root, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Add(formFile, root);
        }

        public string Add(IFormFile formFile, string root)
        {

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string extension = Path.GetExtension(formFile.FileName);
            string guid = Guid.NewGuid().ToString();
            string filePath = guid + extension;
            using (FileStream fileStream = File.Create(root + filePath))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();//Clear buffers for this stream and causes any buffered data to be written to the file.
                                   //Ara belleğe alınan verilerin dosyaya yazılmasına neden olur bu yüzden arabellekleri temizledik.
                return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
            }


        }
    }
}