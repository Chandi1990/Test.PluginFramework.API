using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.PluginFramework.Core;
using Test.PluginFramework.Core.HelperClasses;
using Test.PluginFramework.Core.Interfaces;

namespace Test.PluginFramework.API.Controllers
{
    public class ImageController : ControllerBase
    {
        private readonly IDocumentService documentService;
        private readonly IPlugin pluginService;
        private readonly IConfiguration configuration;

        public ImageController(IDocumentService _documentService, IConfiguration _configuration, IPlugin _pluginService)
        {
            documentService = _documentService;
            configuration = _configuration;
            pluginService = _pluginService;
        }

        [HttpPost("api/upload")]
        [SwaggerOperation(Summary = "File Upload", Description = "File Upload", OperationId = "uploadFile", Tags = new[] { "Controllers" })]
        public async Task<IActionResult> UploadFile(List<IFormFile> formFile)
        {
            var response = new List<DocumentDto>();
            try
            {
                response = await documentService.UploadImages(formFile, "jpg");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new JsonResult(response);
        }

        [HttpGet("api/upload/get")]
        [SwaggerOperation(Summary = "Get Filters", Description = "Get Filters", OperationId = "getFilters", Tags = new[] { "Controllers" })]
        public async Task<IActionResult> Get()
        {
            Dictionary<string, IFilter> _filters;
            string folderPath = configuration.GetSection("PluginSettings").GetSection("Plugins").Value;
            try
            {
                _filters = pluginService.LoadFilters(folderPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new JsonResult(_filters);
        }

        [HttpPatch("api/upload/applyFilter")]
        [SwaggerOperation(Summary = "Apply Filter Filters", Description = "Get Filters", OperationId = "applyFilter", Tags = new[] { "Controllers" })]
        public async Task<IActionResult> ApplyFilter(List<string> filterNames, string fileName = "716982.jpg")
        {
            List<FilterImage> response = new List<FilterImage>();
            string folderPath = configuration.GetSection("PluginSettings").GetSection("Plugins").Value;
            string imageFolderPath = configuration.GetSection("PluginSettings").GetSection("fileSavePath").Value;
            try
            {

                response.AddRange(pluginService.ApplyPlugin(imageFolderPath, folderPath, filterNames.ToArray()));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new JsonResult(response);
        }
    }
}
