using System;
using System.Collections.Generic;

namespace DL {
    public class QueryOptions<T> where T: class {
        public IList<Func<T, bool>> Conditions { get; set; }
        public IList<string> Includes { get; set; }

        public QueryOptions() {
            Conditions = new List<Func<T, bool>>();
            Includes = new List<string>();
        }
    }
}