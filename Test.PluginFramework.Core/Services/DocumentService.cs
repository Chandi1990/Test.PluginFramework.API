using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.PluginFramework.Core.HelperClasses;
using Test.PluginFramework.Core.Interfaces;

namespace Test.PluginFramework.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IConfiguration config;

        public DocumentService(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<DocumentDto>> UploadImages(List<IFormFile> files, string type)
        {
            var documents = new List<DocumentDto>();
            string folderPath = config.GetSection("PluginSettings").GetSection("fileSavePath").Value;

            foreach (var selectedFile in files)
            {
                if (selectedFile is null || selectedFile.Length == 0) throw new Exception("File selection error");

                string fileType = selectedFile.ContentType.Split('/')[1];
                string fileName = new Random().Next(1, 1000000).ToString() + @"." + type;
                string filePath = Path.Combine(folderPath + @"/" + fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(filePath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    selectedFile.CopyToAsync(fileStream);
                }

                documents.Add(new DocumentDto
                {
                    FileName = fileName,
                    CurrentFileType = fileType,
                    NewFileType = ".png",
                    Url = filePath
                });

            }

            return documents.ToList();
        }
    }
}
