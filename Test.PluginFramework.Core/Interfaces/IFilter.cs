using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Test.PluginFramework.Core
{
    public interface IFilter
    {
        Image RunPlugin(Image src);
        string Name { get; }

    }
}
