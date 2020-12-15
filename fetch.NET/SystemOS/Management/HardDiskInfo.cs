using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fetch.NET.SystemOS.Management
{
    public static class HardDiskInfo
    {
        public static string getHd()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            int hdAvailable = ConvertBytesToGB(drives[0].AvailableFreeSpace);
            int hdTotal = ConvertBytesToGB(drives[0].TotalSize);

            return hdAvailable + "GiB / " + hdTotal + " GiB";
        }

        private static int ConvertBytesToGB(long bytes)
        {
            return (int)((double)(bytes >> 20) / 1024);
        }
    }
}
