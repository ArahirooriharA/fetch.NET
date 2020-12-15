using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace fetch.NET.SystemOS.Management
{
    public static class ProcessHelper
    {
        public static Process getProcess(string arguments)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c "+arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                }
            };
        }
    }
}
