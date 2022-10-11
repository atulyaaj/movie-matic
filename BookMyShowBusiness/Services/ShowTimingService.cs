using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class ShowTimingService
    {
        IShowTimingRepository _showTimingRepository;
        public ShowTimingService(IShowTimingRepository showTimingRepository)
        {
            _showTimingRepository=showTimingRepository;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _showTimingRepository.AddShowTiming(showTiming);
        }
        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _showTimingRepository.UpdateShowTiming(showTiming);
        }
        public void DeleteShowTiming(int showTimingId)
        {
            _showTimingRepository.DeleteShowTiming(showTimingId);
        }
        public void GetShowTimingById(int showTimingId)
        {
            _showTimingRepository.GetShowTimingById(showTimingId);
        }
        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return _showTimingRepository.GetShowTimings();
        }
    }
}
