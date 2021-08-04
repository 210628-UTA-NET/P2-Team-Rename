using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IAvailability
    {
        Task<List<Availability>> GetAll();
        Task<Availability> Get(string p_id);
        Task<Availability> Save(Availability p_availability);
        void Edit(Availability p_availability);
        void Delete(string p_id);
    }

}