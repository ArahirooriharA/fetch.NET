using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace fetch.NET.SystemOS.Management
{
    public static class OSInfo
    {
        private static Dictionary<string, string> releaseId = new Dictionary<string, string>()
        {
            ["10240"] = "1507",
            ["10586"] = "1511",
            ["14393"] = "1607",
            ["15063"] = "1703",
            ["16299"] = "1709",
            ["17134"] = "1803",
            ["17763"] = "1809",
            ["18362"] = "1903",
            ["18363"] = "1909",
            ["19041"] = "2004"
        };
        public static string GetName()
        {
            string osname = "OS: ";
            Process proc = ProcessHelper.getProcess("wmic os get name");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Contains("Windows"))
                        return osname + line.Split("|")[0];
                }
            }
            return null;
        }

        public static string GetManufacturer()
        {
            string manufacturer = "Manufacturer: ";
            Process proc = ProcessHelper.getProcess("wmic computersystem get model, manufacturer");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Length > 2)
                    {
                        string[] words = line.Split(" ");
                        foreach (var x in words)
                        {
                            if (x.Length > 3 && !x.Contains("Model") && !x.Contains("Manufacturer"))
                                manufacturer += x + " ";
                        }

                    }
                }
            }
            return manufacturer;
        }

        public static string GetBuild()
        {
            string osBuild = "";
            Process proc = ProcessHelper.getProcess("wmic os get buildNumber");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (releaseId.TryGetValue(line.Trim(), out osBuild))
                        return "Build: " + osBuild;
                }
            }
            return null;
        }

        public static string GetUptime()
        {
            string osUptime = "";
            Process proc = ProcessHelper.getProcess("wmic os get lastbootuptime");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Trim().Length > 16)
                    {
                        int year = Convert.ToInt32(line.Substring(0, 4));
                        int month = Convert.ToInt32(line.Substring(4, 2));
                        int days = Convert.ToInt32(line.Substring(6, 2));
                        int hours = Convert.ToInt32(line.Substring(8, 2));
                        int minutes = Convert.ToInt32(line.Substring(10, 2));
                        int seconds = Convert.ToInt32(line.Substring(12, 2));

                        var date = new DateTime(year, month, days, hours, minutes, seconds);
                        TimeSpan uptime = DateTime.Now - date;
                        return osUptime += (int)uptime.TotalHours + " hours, " + uptime.Minutes +" mins";
                    }
                }
            }
            return null;
        }
    }
}
