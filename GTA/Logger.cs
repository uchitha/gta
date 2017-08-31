using System;
using System.Collections.Generic;
using System.Text;

namespace GTA
{
    public class Logger
    {
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Error(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Info(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
