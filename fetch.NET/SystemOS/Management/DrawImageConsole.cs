using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace fetch.NET.SystemOS.Management
{
    public static class DrawImageConsole
    {
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        public static void Draw()
        {
            var handler = GetConsoleHandle();

            using (var graphics = Graphics.FromHwnd(handler))
            using (var image = Image.FromFile("img101.png"))
                graphics.DrawImage(image, 10, Console.CursorTop, 200, 200);
        }
    }
}
