using BookMyShowData;
using BookMyShowEntity;
using System;
using System.Collections.Generic;

namespace BookMyShowBusiness
{
    public class MovieBLL
    {

        MovieDAL movieDAL;
        public MovieBLL(MovieDAL movieDAL)
        {
            this.movieDAL = movieDAL;
        }


        public string AddMovieBLL(Movie movie)
        {
            return movieDAL.AddMovieDAL(movie);
        }
        public string UpdateMovieBLL(Movie movie)
        {
            return movieDAL.UpdateMovieDAL(movie);
        }
        public string DeleteMovieBLL(int movieId)
        {
            return movieDAL.DeleteMovieDAL(movieId);
        }
        public List<Movie> ShowAllBLL()
        {
            return movieDAL.ShowAllDAL();
        }
        public List<Movie> ShowAllByMovieTypeBLL(string type)
        {
            return movieDAL.ShowAllByMovieTypeDAL(type);
        }
        public Movie ShowMovieByIdBLL(int movieId)
        {
            return movieDAL.ShowMovieByIdDAL(movieId);
        }

    }
}
