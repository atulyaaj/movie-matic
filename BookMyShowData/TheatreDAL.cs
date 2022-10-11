using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class TheatreDAL
    {
        MovieDbContext db = null;
        public TheatreDAL(MovieDbContext db)
        {
            this.db = db;
        }

        public string AddTheatreDAL(Theatre theatre)
        {
            //db = new MovieDbContext();
            db.theatres.Add(theatre);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateTheatreDAL(Theatre theatre)
        {
            //db = new MovieDbContext();
            db.Entry(theatre).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteTheatreDAL(int theatreId)
        {
            //db = new MovieDbContext();
            Theatre theatreObj = db.theatres.Find(theatreId);
            db.Entry(theatreObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Theatre> ShowAllTheatreDAL()
        {
            //db = new MovieDbContext();
            List<Theatre> theatreList = db.theatres.ToList();
            return theatreList;
        }
        public List<Theatre> ShowAllByTheatreAddressDAL(string address)
        {
            //db = new MovieDbContext();
            List<Theatre> theatreList = db.theatres.ToList();

            //linq query-select * from movies where movietype='type'
            var result = from theatres in theatreList
                         where theatres.Address == address
                         orderby theatres.Name
                         select new Theatre
                         {
                             Id = theatres.Id,
                             Name = theatres.Name
                         };
            List<Theatre> theatreResult = new List<Theatre>();
            foreach (var item in result)//linq queary execution
            {
                theatreResult.Add(item);
            }
            return theatreResult;
        }
        public Theatre ShowTheatreByIdDAL(int theatreId)
        {
            //db = new MovieDbContext();
            Theatre theatre = db.theatres.Find(theatreId);
            return theatre;
        }
    }
}
