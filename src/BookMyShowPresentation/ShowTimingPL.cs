using BookMyShowBusiness;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowPresentation
{
    public class ShowTimingPL
    {
        public void AddShowTiming()
        {
            ShowTimingBLL showTimingBLL=new ShowTimingBLL();
            ShowTiming showTiming=new ShowTiming();
            Console.Write("Enter Movie Id:");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Id:");
            showTiming.TheatreId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Show Time:");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            showTimingBLL.AddShowTimingBLL(showTiming);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Show Time Added Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write(msg);
        }
        public void UpdateShowTiming()
        {
            ShowTimingBLL showTimingBLL = new ShowTimingBLL();
            ShowTiming showTiming = new ShowTiming();
            Console.Write("Enter Show Time Id:");
            showTiming.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Movie Id:");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Id:");
            showTiming.TheatreId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Show Time:");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());

            showTimingBLL.UpdateShowTimingBLL(showTiming);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Show Time Updated Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DeleteShowTiming()
        {
            ShowTimingBLL showTimingBLL = new ShowTimingBLL();
            Console.Write("Enter Show Time Id: ");
            int showTimingId = Convert.ToInt32(Console.ReadLine());
            showTimingBLL.DeleteShowTimingBLL(showTimingId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Show Time Deleted Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
            //string msg = movieOperations.DeleteMovie(movieId);
            //Console.Write(msg);
        }
        public void ShowAllShowTiming()
        {
            ShowTimingBLL showTimingBLL = new ShowTimingBLL();
            List<ShowTiming> showTimings = showTimingBLL.ShowAllShowTimingBLL();
            foreach (var item in showTimings)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Show Time Id:" + item.Id);
                Console.WriteLine("Movie Id:" + item.MovieId);
                Console.WriteLine("Theatre Id:" + item.TheatreId);
                Console.WriteLine("Show Time:" + item.ShowTime);
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ShowTimingById()
        {
            ShowTimingBLL showTimingBLL = new ShowTimingBLL();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter Show Time Id: ");
            int showTimingId = Convert.ToInt32(Console.ReadLine());
            ShowTiming showTiming = showTimingBLL.ShowTimingByIdBLL(showTimingId);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Movie Id:" + showTiming.MovieId);
            Console.WriteLine("Theatre id:" + showTiming.TheatreId);
            Console.WriteLine("Show Time:" + showTiming.ShowTime);
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void GetShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to add a ShowTime\n" +
            "2) Press 2 to show all ShowTime\n" +
            "3) Press 3 to delete a ShowTime\n" +
            "4) Press 4 to display all ShowTime by Id\n" +
            "5) Press 5 to update a ShowTime\n" +
            "6) Press 6 to exit");
        }
        public void ShowTimingSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome-to-Show-Timing-Operations----------------");
            GetShowMenu();
            int inputCaseBook = int.Parse(Console.ReadLine());
            switch (inputCaseBook)
            {
                case 1:
                    AddShowTiming();
                    ShowTimingSection();
                    break;
                case 2:
                    ShowAllShowTiming();
                    ShowTimingSection();
                    break;
                case 3:
                    DeleteShowTiming();
                    ShowTimingSection();
                    break;
                case 4:
                    ShowTimingById();
                    ShowTimingSection();
                    break;
                case 5:
                    UpdateShowTiming();
                    ShowTimingSection();
                    break;
                case 6:
                    break;
            }
        }
    }
}
