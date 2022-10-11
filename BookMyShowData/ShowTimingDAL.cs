using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class ShowTimingDAL
    {
        MovieDbContext db = null;
        public ShowTimingDAL(MovieDbContext db)
        {
            this.db = db;
        }

        public string AddShowTimingDAL(ShowTiming showTiming)
        {
            //db = new MovieDbContext();
            db.showTimings.Add(showTiming);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateShowTimingDAL(ShowTiming showTiming)
        {
            //db = new MovieDbContext();
            db.Entry(showTiming).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteShowTimingDAL(int showTimingId)
        {
            //db = new MovieDbContext();
            ShowTiming showTimingObj = db.showTimings.Find(showTimingId);
            db.Entry(showTimingObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<ShowTiming> ShowAllShowTimingDAL()
        {
            //db = new MovieDbContext();
            List<ShowTiming> showTimingList = db.showTimings.ToList();
            return showTimingList;
        }
        public ShowTiming ShowTimingByIdDAL(int showTimingId)
        {
            //db = new MovieDbContext();
            ShowTiming showTiming = db.showTimings.Find(showTimingId);
            return showTiming;
        }
    }
}
