using fetch.NET.Config;
using fetch.NET.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace fetch.NET.SystemOS.Management
{
    public static class ManagementInfo
    {
        private static WindowsSystem so;

        public static void Run(ConfigApp config)
        {
            so = new WindowsSystem();

            List<string> listaCores = new List<string>();
            listaCores.AddRange(config.ListOfColors);
            if (listaCores.Contains(config.ForegroundColor))
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), NormalizeColorString(config.ForegroundColor));
            }

            so.UserName = Environment.UserName;
            if (Environment.Is64BitOperatingSystem) { so.OSType = "OS_Arch: 64-Bit"; } else { so.OSType = "OS_Arch 32-Bit"; }
            so.Hd = HardDiskInfo.getHd();
            so.Host = "Host: " + Environment.MachineName;
            so.RamMaximum = HardwareInfo.getTotalRam();
            so.RamConsumed = HardwareInfo.getUsageRam();
            so.Resolution = ResolutionInfo.getResolution();
            so.SystemNome = OSInfo.GetName();
            so.CPUInfo = HardwareInfo.getCPU();
            so.GPUInfo = HardwareInfo.getGPU();
            so.PCManufacturer = OSInfo.GetManufacturer();
            so.Build = OSInfo.GetBuild();
            so.Uptime = "Uptime: " + OSInfo.GetUptime();

            Console.Write(so);
            ConsoleWorker.WriteAll(so.ArrayTheProprierties());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string NormalizeColorString(string txt)
        {
            char firstLetterUpper = char.ToUpper(txt[0]);
            if (txt.Contains("dark"))
            {
                char nextLetterUpper = char.ToUpper(txt[4]);
                var convertedString = firstLetterUpper + txt.Substring(1, 3) + nextLetterUpper + txt.Substring(5);
                return convertedString;
            }
            return firstLetterUpper + txt.Substring(1);
        }
    }
}
