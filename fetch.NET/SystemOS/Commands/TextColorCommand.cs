using fetch.NET.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace fetch.NET.SystemOS.Commands
{
    public class TextColorCommand : ICommand
    {
        private const string _name = "-f <color>";
        public string Name => _name;

        public string Description()
        {
            return "Change the color of the text";
        }

        public void Run(ConfigApp appSettings, string color)
        {
            appSettings.ForegroundColor = color;
        }
    }
}
