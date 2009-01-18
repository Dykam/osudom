using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDebug
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Test");
            Console.WriteLine("Ending Test");
        }

        public static void Pause()
        {
            Console.WriteLine("Press a key to continue. . .");
            Console.ReadKey(false);
        }
    }
}
