using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface ITheatreRepository
    {
        void AddTheatre(Theatre theatre);
        void UpdateTheatre(Theatre theatre);
        void DeleteTheatre(int theatreId);
        Theatre GetTheatreById(int theatreId);
        IEnumerable<Theatre> GetTheatres();
    }
}
