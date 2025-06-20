using BookMyShowBusiness;
using BookMyShowEntity;
using System;
using System.Collections.Generic;

namespace BookMyShowPresentation
{
    public class MoviePL
    {
        public void AddMovie()
        {
            MovieBLL movieBLL = new MovieBLL();
            Movie movie = new Movie();
            Console.Write("Enter Movie Name:");
            movie.Name = Console.ReadLine();
            Console.Write("Enter Movie Description:");
            movie.MovieDesc = Console.ReadLine();
            Console.Write("Enter Movie Type:");
            movie.MovieType = Console.ReadLine();
            movieBLL.AddMovieBLL(movie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Movie Added Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write(msg);
        }
        public void UpdateMovie()
        {
            MovieBLL movieBLL = new MovieBLL();
            Movie movie = new Movie();
            Console.Write("Enter Movie Id:");
            movie.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Movie Name:");
            movie.Name = Console.ReadLine();
            Console.Write("Enter Movie Description:");
            movie.MovieDesc = Console.ReadLine();
            Console.Write("Enter Movie Type:");
            movie.MovieType = Console.ReadLine();

            movieBLL.UpdateMovieBLL(movie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Movie Updated Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAllMovies()
        {
            MovieBLL movieBLL = new MovieBLL();
            List<Movie> movies = movieBLL.ShowAllBLL();
            foreach (var item in movies)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Id:" + item.Id);
                Console.WriteLine("Name:" + item.Name);
                Console.WriteLine("Descriptions:" + item.MovieDesc);
                Console.WriteLine("Type:" + item.MovieType);
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DeleteMovie()
        {
            MovieBLL movieBLL = new MovieBLL();
            Console.Write("Enter MovieId: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            movieBLL.DeleteMovieBLL(movieId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Movie Deleted Successfully............");
            Console.ForegroundColor = ConsoleColor.White;
            //string msg = movieOperations.DeleteMovie(movieId);
            //Console.Write(msg);
        }
        public void ShowAllByMovieType()
        {
            MovieBLL movieBLL = new MovieBLL();
            Console.WriteLine("Enter Movie Type:");
            string movieType = Console.ReadLine();
            List<Movie> movies = movieBLL.ShowAllByMovieTypeBLL(movieType);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in movies)
            {
                Console.WriteLine("Id:" + item.Id);
                Console.WriteLine("Name:" + item.Name);
            }
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowMovieById()
        {
            MovieBLL movieBLL = new MovieBLL();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter MovieId: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Movie movie=movieBLL.ShowMovieByIdBLL(movieId);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Movie Name:" + movie.Name);
            Console.WriteLine("Movie Descriptions:" + movie.MovieDesc);
            Console.WriteLine("Movie Type:" + movie.MovieType);
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void GetMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Press 1 to add a movie\n" +
            "2) Press 2 to show all movie\n" +
            "3) Press 3 to delete a movie\n" +
            "4) Press 4 to show all movie by movie type\n" +
            "5) Press 5 to show all movie by movie id\n" +
            "6) Press 6 to update a movie\n" +
            "7) Press 7 to exit");
        }
        public void BookMyShowSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome-to-Movie-Operations----------------");
            GetMenu();
            int inputCaseBook = int.Parse(Console.ReadLine());
            switch (inputCaseBook)
            {
                case 1:
                    AddMovie();
                    BookMyShowSection();
                    break;
                case 2:
                    ShowAllMovies();
                    BookMyShowSection();
                    break;
                case 3:
                    DeleteMovie();
                    BookMyShowSection();
                    break;
                case 4:
                    ShowAllByMovieType();
                    BookMyShowSection();
                    break;
                case 5:
                    ShowMovieById();
                    BookMyShowSection();
                    break;
                case 6:
                    UpdateMovie();
                    BookMyShowSection();
                    break;
                case 7:
                    break;
            }
        }
    }
}
