using BookMyShowData;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness
{
    public class TheatreBLL
    {
        TheatreDAL theatreDAL;
        public TheatreBLL(TheatreDAL theatreDAL)
        {
            this.theatreDAL = theatreDAL;
        }

        public string AddTheatreBLL(Theatre theatre)
        {
            return theatreDAL.AddTheatreDAL(theatre);
        }
        public string UpdateTheatreBLL(Theatre theatre)
        {
            return theatreDAL.UpdateTheatreDAL(theatre);
        }
        public string DeleteTheatreBLL(int theatreId)
        {
            return theatreDAL.DeleteTheatreDAL(theatreId);
        }
        public List<Theatre> ShowAllTheatreBLL()
        {
            return theatreDAL.ShowAllTheatreDAL();
        }
        public List<Theatre> ShowAllByTheatreAddressBLL(string location)
        {
            return theatreDAL.ShowAllByTheatreAddressDAL(location);
        }
        public Theatre ShowTheatreByIdBLL(int theatreId)
        {
            return theatreDAL.ShowTheatreByIdDAL(theatreId);
        }

    }
}
