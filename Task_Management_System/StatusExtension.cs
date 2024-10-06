using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public enum Status
    {
        Completed,
        NotStarted,
        OnHold,
        InProgress
    }
    public static class StatusExtensions
    {
        public static void DisplayStatusOptions()
        {
            Console.WriteLine("Enter status:");
            foreach (Status status in Enum.GetValues(typeof(Status)))
            {
                Console.Write($"{(int)status + 1}. ");
                PrintColoredStatus(status);
                if((int)status + 1 != 4)
                    Console.Write(" | ");
            }
            Console.WriteLine();
        }

        public static Status ReadStatus()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
                {
                    return (Status)(choice - 1);
                }
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }

        public static void PrintColoredStatus(Status status)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            switch (status)
            {
                case Status.Completed:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Status.NotStarted:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Status.OnHold:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Status.InProgress:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
            Console.Write(status);
            Console.ForegroundColor = originalColor;
        }
    }
}
