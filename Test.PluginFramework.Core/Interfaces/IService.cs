using System;
using System.Collections.Generic;
using System.Text;

namespace Test.PluginFramework.Core
{
    public interface IService
    {
        bool IsRunning { get; }
        void Start();
        void Stop();
    }
}
