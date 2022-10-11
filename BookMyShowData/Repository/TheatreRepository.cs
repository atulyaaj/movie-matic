using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class TheatreRepository : ITheatreRepository
    {
        MovieDbContext _movieDbContext;
        public TheatreRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddTheatre(Theatre theatre)
        {
            _movieDbContext.theatres.Add(theatre);
            _movieDbContext.SaveChanges();
        }

        public void DeleteTheatre(int theatreId)
        {
            var theatre = _movieDbContext.theatres.Find(theatreId);
            _movieDbContext.theatres.Remove(theatre);
            _movieDbContext.SaveChanges();
        }

        public Theatre GetTheatreById(int theatreId)
        {
            return _movieDbContext.theatres.Find(theatreId);
        }

        public IEnumerable<Theatre> GetTheatres()
        {
            return _movieDbContext.theatres.ToList();
        }

        public void UpdateTheatre(Theatre theatre)
        {
            _movieDbContext.Entry(theatre).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
    }
}
