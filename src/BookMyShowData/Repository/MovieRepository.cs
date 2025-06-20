using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void AddMovie(Movie movie)
        {
            _movieDbContext.movies.Add(movie);
            _movieDbContext.SaveChanges();
        }

        public void DeleteMovie(int movieId)
        {
            var movie = _movieDbContext.movies.Find(movieId);
            _movieDbContext.movies.Remove(movie);
            _movieDbContext.SaveChanges();
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieDbContext.movies.Find(movieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieDbContext.movies.ToList();
        }

        public void UpdateMovie(Movie movie)
        {
            _movieDbContext.Entry(movie).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
    }
}
