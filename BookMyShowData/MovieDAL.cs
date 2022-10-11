using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class MovieDAL
    {
        MovieDbContext db = null;
        public MovieDAL(MovieDbContext db)
        {
            this.db = db;
        }

        public string AddMovieDAL(Movie movie)
        {
            //db = new MovieDbContext();
            db.movies.Add(movie);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateMovieDAL(Movie movie)
        {
            //db = new MovieDbContext();
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteMovieDAL(int movieId)
        {
            //db = new MovieDbContext();
            Movie movieObj = db.movies.Find(movieId);
            db.Entry(movieObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Movie> ShowAllDAL()
        {
            //db = new MovieDbContext();
            List<Movie> movieList = db.movies.ToList();
            return movieList;
        }
        public List<Movie> ShowAllByMovieTypeDAL(string type)
        {
            //db = new MovieDbContext();
            List<Movie> movieList = db.movies.ToList();

            //linq query-select * from movies where movietype='type'
            var result = from movies in movieList
                         where movies.MovieType == type
                         orderby movies.Name
                         select new Movie
                         {
                             Id = movies.Id,
                             Name = movies.Name
                         };
            List<Movie> movieResult = new List<Movie>();
            foreach (var item in result)//linq queary execution
            {
                movieResult.Add(item);
            }
            return movieResult;
        }
        public Movie ShowMovieByIdDAL(int movieId)
        {
            //db = new MovieDbContext();
            Movie movie = db.movies.Find(movieId);
            return movie;
        }
    }
}
