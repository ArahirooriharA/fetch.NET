using fetch.NET.Config;
using fetch.NET.SystemOS.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace fetch.NET.SystemOS.Commands
{
    public class HelpCommand : ICommand
    {
        private const string _name = "-h";

        public string Name => _name;

        public string Description()
        {
            return "Display all commands and how use them";
        }

        public void Run(ConfigApp appSettings, string args)
        {
            ConsoleWorker.WriteHelp(appSettings.CommandList);
        }
    }
}
