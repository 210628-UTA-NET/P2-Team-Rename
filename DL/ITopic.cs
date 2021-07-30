using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ITopic
    {
        Task<List<Topic>> GetAll();
        Task<Topic> Get(string p_id);
        Task<Topic> Save(Topic p_topic);
        Task<Topic> Edit(Topic p_topic);
        void Delete(string p_id);
    }
}