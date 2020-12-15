using fetch.NET.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace fetch.NET.SystemOS.Commands
{
    public class BackgroundColorCommand : ICommand
    {
        private const string _name = "-b <color>";
        public string Name { get => _name;}

        public string Description()
        {
            return "Change the background color of the cmd";
        }

        public void Run(ConfigApp appSettings, string color)
        {
            appSettings.BackgroundColor = color;
        }
    }
}
