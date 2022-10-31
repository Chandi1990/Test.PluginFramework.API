using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using Test.PluginFramework.Core.HelperClasses;
using Test.PluginFramework.Core.Interfaces;

namespace Test.PluginFramework.Core.Services
{
    public class PluginService : IPlugin
    {
        Dictionary<string, IFilter> _filters;
        private string _folderPath;
        public string Name { get; set; }

        public PluginService()
        {
            _filters = new Dictionary<string, IFilter>();
            var assembly = Assembly.GetExecutingAssembly();
            _folderPath = Path.GetDirectoryName(assembly.Location);
        }


        public Dictionary<string, IFilter> LoadFilters(string folder)
        {
            _filters.Clear();
            foreach (var dll in Directory.GetFiles(folder, "*.dll"))
            {
                try
                {
                    var asm = Assembly.LoadFrom(dll);
                    foreach (var type in asm.GetTypes())
                    {
                        if (type.GetInterface("IFilter") == typeof(IFilter))
                        {
                            var filter = Activator.CreateInstance(type) as IFilter;
                            _filters[filter.Name] = filter;
                        }
                    }

                }
                catch (BadImageFormatException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _filters;
        }

        public List<FilterImage> ApplyPlugin(string imageFolderPath, string pluginsFolderPath, string[] filters)
        {
            List<FilterImage> result = new List<FilterImage>();
            try
            {
                Dictionary<string, IFilter> _filters = LoadFilters(pluginsFolderPath);

                foreach (var imageFile in Directory.GetFiles(imageFolderPath, "716982" + "?.png"))
                {
                    foreach (var filter in filters)
                    {
                        result.Add(new FilterImage { FilterName = _filters[filter].Name, ImagePath = imageFile });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public Image RunPlugin(Image src)
        {
            throw new NotImplementedException();
        }
    }
}
