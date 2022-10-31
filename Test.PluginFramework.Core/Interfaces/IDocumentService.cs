using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.PluginFramework.Core.HelperClasses;

namespace Test.PluginFramework.Core.Interfaces
{
    public interface IDocumentService
    {
        Task<List<DocumentDto>> UploadImages(List<IFormFile> files, string documnetType);
        //Task<Dictionary<string, IFilter>> ApplyFilter
    }
}
