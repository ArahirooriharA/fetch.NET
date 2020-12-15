using fetch.NET.SystemOS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fetch.NET.Config
{
    public class ConfigApp
    {
        public string[] ListOfColors { get; set; }
        public string ForegroundColor { get; set; }
        public string BackgroundColor { get; set; }
        public string PathToImage { get; set; }
        public List<ICommand> CommandList { get; set; }

        public ConfigApp()
        {
            ListOfColors = Array.ConvertAll(Enum.GetNames(typeof(ConsoleColor)), color => color.ToLower()).ToArray();
            //CommandList = new List<ICommand>() { new BackgroundColorCommand(), new TextColorCommand(), new HelpCommand() };
        }
    }
}
