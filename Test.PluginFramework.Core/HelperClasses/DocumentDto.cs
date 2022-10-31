using System;
using System.Collections.Generic;
using System.Text;

namespace Test.PluginFramework.Core.HelperClasses
{
    public class DocumentDto
    {
        public string FileName { get; set; }
        public string CurrentFileType { get; set; }
        public string NewFileType { get; set; }
        public string Url { get; set; }
    }
}
