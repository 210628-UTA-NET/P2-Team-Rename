using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IUser
    {
        Task<List<User>> GetAll();
        Task<User> Get(string p_id);
        Task<User> Save(User p_user);
        void Edit(User p_user);
        void Delete(string p_id);
    }
}