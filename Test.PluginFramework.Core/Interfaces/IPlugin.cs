using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Test.PluginFramework.Core.HelperClasses;

namespace Test.PluginFramework.Core.Interfaces
{
    public interface IPlugin : IFilter
    {
        Dictionary<string, IFilter> LoadFilters(string folder);
        List<FilterImage> ApplyPlugin(string imagePath, string pluginsFolderPath, string[] filterName);
    }
}
