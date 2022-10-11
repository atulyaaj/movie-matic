using BookMyShowData;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness
{
    public class ShowTimingBLL
    {
        ShowTimingDAL showTimingDAL;
        public ShowTimingBLL(ShowTimingDAL showTimingDAL)
        {
            this.showTimingDAL = showTimingDAL;
        }

        public string AddShowTimingBLL(ShowTiming showTiming)
        {
            return showTimingDAL.AddShowTimingDAL(showTiming);
        }
        public string UpdateShowTimingBLL(ShowTiming showTiming)
        {
            return showTimingDAL.UpdateShowTimingDAL(showTiming);
        }
        public string DeleteShowTimingBLL(int showTimingId)
        {
            return showTimingDAL.DeleteShowTimingDAL(showTimingId);
        }
        public List<ShowTiming> ShowAllShowTimingBLL()
        {
            return showTimingDAL.ShowAllShowTimingDAL();
        }
        public ShowTiming ShowTimingByIdBLL(int showTimingId)
        {
            return showTimingDAL.ShowTimingByIdDAL(showTimingId);
        }
    }
}
