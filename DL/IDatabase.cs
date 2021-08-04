using System.Collections.Generic;

namespace DL {
    public interface IDatabase<T> where T: class {
        void Create(T model);
        void Delete(T model);
        IList<T> Query(QueryOptions<T> options);
        T FindSingle(QueryOptions<T> options);
        void Update(T model);
        void Save();
        void FlagForRemoval(T model);
    }
}