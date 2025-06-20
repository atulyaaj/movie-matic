using BookMyShowBusiness;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowPresentation
{
    public class TheatrePL
    {

        
        public void AddTheatre()
        {
            TheatreBLL theatreBLL=new TheatreBLL();
            Theatre theatre = new Theatre();
            Console.Write("Enter Theatre Name:");
            theatre.Name = Console.ReadLine();
            Console.Write("Enter Theatre Address:");
            theatre.Address = Console.ReadLine();
            Console.Write("Enter Comments:");
            theatre.Comments = Console.ReadLine();
            theatreBLL.AddTheatreBLL(theatre);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Theatre Added Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write(msg);
        }
        public void UpdateTheatre()
        {
            TheatreBLL theatreBLL = new TheatreBLL();
            Theatre theatre = new Theatre();
            Console.Write("Enter Theatre Id:");
            theatre.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Theatre Name:");
            theatre.Name = Console.ReadLine();
            Console.Write("Enter Theatre Address:");
            theatre.Address = Console.ReadLine();
            Console.Write("Enter Comments:");
            theatre.Comments = Console.ReadLine();

            theatreBLL.UpdateTheatreBLL(theatre);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Theatre Updated Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAllTheatres()
        {
            TheatreBLL theatreBLL = new TheatreBLL();
            List<Theatre> theatres = theatreBLL.ShowAllTheatreBLL();
            foreach (var item in theatres)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Id:" + item.Id);
                Console.WriteLine("Name:" + item.Name);
                Console.WriteLine("Address:" + item.Address);
                Console.WriteLine("Comments:" + item.Comments);
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DeleteTheatre()
        {
            TheatreBLL theatreBLL = new TheatreBLL();
            Console.Write("Enter TheatreId: ");
            int theatreId = Convert.ToInt32(Console.ReadLine());
            theatreBLL.DeleteTheatreBLL(theatreId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Theatre Deleted Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
            //string msg = movieOperations.DeleteMovie(movieId);
            //Console.Write(msg);
        }
        public void ShowAllByTheatreAddress()
        {
            TheatreBLL theatreBLL = new TheatreBLL();
            Console.WriteLine("Enter Theatre Address:");
            string theatreAddress = Console.ReadLine();
            List<Theatre> theatres = theatreBLL.ShowAllByTheatreAddressBLL(theatreAddress);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in theatres)
            {
                Console.WriteLine("Id:" + item.Id);
                Console.WriteLine("Theatre Name:" + item.Name);
            }
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowTheatreById()
        {
            TheatreBLL theatreBLL = new TheatreBLL();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter Theatre Id: ");
            int theatreId = Convert.ToInt32(Console.ReadLine());
            Theatre theatre = theatreBLL.ShowTheatreByIdBLL(theatreId);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Theatre Name:" + theatre.Name);
            Console.WriteLine("Theatre Address:" + theatre.Address);
            Console.WriteLine("Comments:" + theatre.Comments);
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void GetTheatreMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to add a theatre\n" +
            "2) Press 2 to show all theatres\n" +
            "3) Press 3 to delete a theatre\n" +
            "4) Press 4 to show all movie by theatre address\n" +
            "5) Press 5 to show all movie by theatre id\n" +
            "6) Press 6 to update a theatre\n" +
            "7) Press 7 to exit");
        }
        public void TheatreSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome-to-Theatre-Operations----------------");
            GetTheatreMenu();
            int inputCaseBook = int.Parse(Console.ReadLine());
            switch (inputCaseBook)
            {
                case 1:
                    AddTheatre();
                    TheatreSection();
                    break;
                case 2:
                    ShowAllTheatres();
                    TheatreSection();
                    break;
                case 3:
                    DeleteTheatre();
                    TheatreSection();
                    break;
                case 4:
                    ShowAllByTheatreAddress();
                    TheatreSection();
                    break;
                case 5:
                    ShowTheatreById();
                    TheatreSection();
                    break;
                case 6:
                    UpdateTheatre();
                    TheatreSection();
                    break;
                case 7:
                    break;
            }
        }
    }
}
