using fetch.NET.Config;
using fetch.NET.System;
using fetch.NET.SystemOS.Commands;
using fetch.NET.SystemOS.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace fetch.NET
{
    class fetch
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            string ConfigFolder = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 23);
            ConfigFolder += @"\Configuration\appsettings.txt";

            string configDeserialize = File.ReadAllText(ConfigFolder);
            JsonSerializerSettings setting = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            ConfigApp appSettings = JsonConvert.DeserializeObject<ConfigApp>(configDeserialize, setting);
            if (args.Length > 0)
            {
                foreach (ICommand command in appSettings.CommandList)
                {
                    if (args.Length == 2 && command.Name != "-h")
                        command.Run(appSettings, args[1]);
                    else if (args.Length == 1)
                    {
                        command.Run(appSettings, args[0]);
                    }
                }

                string json = JsonConvert.SerializeObject(appSettings, setting);
                File.WriteAllText(ConfigFolder, json);
                if (args.Length == 1)
                    return;
            }
            ManagementInfo.Run(appSettings);
            Console.WriteLine();
            //DrawImageConsole.Draw();
            
        }
    }
}
