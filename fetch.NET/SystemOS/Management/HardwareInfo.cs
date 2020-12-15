using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace fetch.NET.SystemOS.Management
{
    public static class HardwareInfo
    {
        public static int getTotalRam()
        {
            int memoryRamTotal = 0;
            Process proc = ProcessHelper.getProcess("wmic MEMORYCHIP get capacity");
            using(proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    double result;
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Length > 2 && double.TryParse(line, out result))
                        memoryRamTotal += (int)(result/1024/1024);
                        
                }
            }
            return memoryRamTotal;
        }

        public static int getUsageRam()
        {
            Process proc = ProcessHelper.getProcess("wmic OS get FreePhysicalMemory");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    double result;
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Length > 2 && double.TryParse(line, out result))
                        return getTotalRam() - (int)(result / 1000);
                }
            }
            return 0;
        }

        public static string getCPU()
        {
            string cpu = "";
            Process proc = ProcessHelper.getProcess("wmic cpu get Name");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Length > 2 )
                        cpu = line;
                }
            }
            return "CPU: " + cpu;
        }

        public static string getGPU()
        {
            string gpu = "";
            Process proc = ProcessHelper.getProcess("wmic path win32_videocontroller get name");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Length > 2)
                        gpu = line;
                }
            }
            return "GPU: " + gpu;
        }
    }
}
