using fetch.NET.SystemOS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace fetch.NET.SystemOS.Management
{
    public static class ConsoleWorker
    {
        private static int i = Console.CursorTop;
        
        public static void WriteAll(string[] txt)
        {
            i -= 5;
            foreach(var position in txt)
            {
                i += 1;
                Console.SetCursorPosition(30,i);
                Console.Write(position);
            }
        }
        public static void Write(string txt)
        {
            Console.SetCursorPosition(60, i);
            i += 1;
            Console.Write(txt);
        }

        public static void WriteHelp(List<ICommand> commands)
        {
            Console.WriteLine();
            Console.Write("Command");
            Console.SetCursorPosition(20, i);
            Console.Write("Description");
            i++;
            foreach(var command in commands)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(command.Name);
                Console.SetCursorPosition(20, i);
                Console.Write(command.Description());
                i++;
            }
            Console.WriteLine();
        }
    }
}
