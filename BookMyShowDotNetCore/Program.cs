using BookMyShowPresentation;
using System;

namespace BookMyShowDotNetCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Book My Show");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to show Movie Operations \n" +
            "2) Press 2 to show Theatre Operations\n" +
            "3) Press 3 to display Show Timing Operations\n" +
            "4) Press 4 to exit");

            int inputCase = int.Parse(Console.ReadLine());
            switch (inputCase)
            {
                case 1:
                    MoviePL moviePL = new MoviePL();
                    moviePL.BookMyShowSection();
                    break;
                case 2:
                    TheatrePL theatrePL = new TheatrePL();
                    theatrePL.TheatreSection();
                    break;
                case 3:
                    ShowTimingPL showTimingPL = new ShowTimingPL();
                    showTimingPL.ShowTimingSection();
                    break;
                case 4:
                    break;

            }
            Console.Read();
        }
    }
}
