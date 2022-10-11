using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class ShowTimingRepository : IShowTimingRepository
    {
        MovieDbContext _movieDbContext;
        public ShowTimingRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _movieDbContext.showTimings.Add(showTiming);
            _movieDbContext.SaveChanges();
        }

        public void DeleteShowTiming(int showTimingId)
        {
            var showTiming = _movieDbContext.showTimings.Find(showTimingId);
            _movieDbContext.showTimings.Remove(showTiming);
            _movieDbContext.SaveChanges();
        }

        public ShowTiming GetShowTimingById(int showTimingId)
        {
            return _movieDbContext.showTimings.Find(showTimingId);
        }

        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return _movieDbContext.showTimings.ToList();
        }

        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _movieDbContext.Entry(showTiming).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
    }
}
