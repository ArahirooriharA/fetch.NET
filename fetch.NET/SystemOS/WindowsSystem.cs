using fetch.NET.SystemOS.Management;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;

namespace fetch.NET.System
{
    public class WindowsSystem
    {
        public string UserName { get; set; }
        public string SystemNome { get; set; }
        public string PCManufacturer { get; set; }
        public string Build { get; set; }
        public string OSType { get; set; }
        public string Uptime { get; set; }
        public string CPUInfo { get; set; }
        public string GPUInfo { get; set; }
        public int RamConsumed { get; set; }
        public int RamMaximum { get; set; }
        public string Hd { get; set; }
        public string Resolution { get; set; }
        public string Host { get; set; }

        public string[] ArrayTheProprierties()
        {
            return new string[] { UserName, SystemNome, Build, Uptime, PCManufacturer, "MemoryRam: "+RamConsumed+"MiB / " + RamMaximum+"MiB", "HD: " +
                                Hd, OSType, CPUInfo, GPUInfo , Host, Resolution};
        }

        public override string ToString()
        {
            return "       _.-;;-._" + Environment.NewLine +
            "'-..-'|   ||   |" + Environment.NewLine +
            "'-..-'|_.-;;-._|" + Environment.NewLine +
            "'-..-'|   ||   |" + Environment.NewLine +
            "'-..-'|_.-''-._|";
        }
    }
}
