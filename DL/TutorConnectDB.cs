using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL {
    public class TutorConnectDB<T>: IDatabase<T> where T: class {
        private readonly TutorConnectDBContext _context;

        public TutorConnectDB(TutorConnectDBContext context) {
            _context = context;
        }

        public void Create(T model) {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
        }

        public void Delete(T model) {
            _context.Set<T>().Attach(model);
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
        }

        public T FindSingle(QueryOptions<T> options) {
            return Query(options).FirstOrDefault();
        }

        public void FlagForRemoval(T model) {
            _context.Set<T>().Attach(model);
            _context.Set<T>().Remove(model);
        }

        public IList<T> Query(QueryOptions<T> options) {
            // Load relations and subrelations
            var queryableQuery = _context.Set<T>().AsQueryable();
            if (options.Includes != null) {
                foreach (string inc in options.Includes) {
                    queryableQuery = queryableQuery.Include(inc);
                }
            }

            // Add conditions
            var enumerableQuery = queryableQuery.AsEnumerable();
            if (options.Conditions != null) {
                foreach (Func<T, bool> cond in options.Conditions) {
                    enumerableQuery = enumerableQuery.Where(cond);
                }
            }

            return enumerableQuery.Select(o => o).ToList();
        }

        public void Save() {
            _context.SaveChanges();
        }

        public void Update(T model) {
            _context.Set<T>().Attach(model);

            var entry = _context.Entry(model);
            entry.State = EntityState.Modified;

            foreach (var prop in entry.Properties.Where(p => !p.Metadata.IsKey())) {
                if (prop.CurrentValue == null) {
                    prop.IsModified = false;
                }
            }

            _context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}