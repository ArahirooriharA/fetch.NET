using fetch.NET.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace fetch.NET.SystemOS.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Description();
        void Run(ConfigApp appSettings, string args);
    }
}
