using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL {
    public interface IDatabase<T> where T: class {
        void Create(T model);
        void Delete(T model);
        Task<IList<T>> Query(QueryOptions<T> options);
        Task<T> FindSingle(QueryOptions<T> options);
        void Update(T model);
        void Save();
        void FlagForRemoval(T model);
    }
}