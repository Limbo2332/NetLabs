using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_Linq_To_Objects
{
    class MessageHolder
    {
        public static void WriteMessage(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Danger:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.NameOfQuery:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.WriteLine(message + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
