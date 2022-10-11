using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class TheatreService
    {
        ITheatreRepository _theatreRepository;
        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }
        public void AddTheatre(Theatre theatre)
        {
            _theatreRepository.AddTheatre(theatre);
        }
        public void UpdateTheatre(Theatre theatre)
        {
            _theatreRepository.UpdateTheatre(theatre);
        }
        public void DeleteTheatre(int theatreId)
        {
            _theatreRepository.DeleteTheatre(theatreId);
        }
        public void GetTheatreById(int theatreId)
        {
            _theatreRepository.GetTheatreById(theatreId);
        }
        public IEnumerable<Theatre> GetTheatres()
        {
            return _theatreRepository.GetTheatres();
        }
    }
}
