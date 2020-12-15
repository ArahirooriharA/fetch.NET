using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System;

namespace fetch.NET.SystemOS.Management
{
    public static class ResolutionInfo
    {
        public static string getResolution()
        {
            string resolution = "";
            Process proc = ProcessHelper.getProcess("wmic path Win32_VideoController get CurrentHorizontalResolution,CurrentVerticalResolution");
            using (proc)
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    if (line.Length > 4)
                    {
                        string[] words = line.Split(" ");
                        foreach(var word in words)
                        {
                            if (word.Length > 2)
                                resolution = "Resolution: " +words[0] + "x" + word;
                        }
                    }
                }
            }
            return resolution;
        }
    }
}
