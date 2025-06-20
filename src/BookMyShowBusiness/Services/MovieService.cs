using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class MovieService
    {
        IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }
        public void DeleteMovie(int movieId)
        {
            _movieRepository.DeleteMovie(movieId);
        }
        public Movie GetMovieById(int movieId)
        {
            return _movieRepository.GetMovieById(movieId);
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }
    }

}
