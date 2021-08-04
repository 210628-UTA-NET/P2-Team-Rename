using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using DL;
using DL.Entities;

namespace BL {
    public class TutorManager {
        private readonly IDatabase<Tutor> _tutorDB;
        private readonly IList<string> _includes;

        public TutorManager(IDatabase<Tutor> tutorDB) {
            _tutorDB = tutorDB;
            _includes = new List<string> {
                "User",
                "DegreesOrCerts"
            };
        }
    }
}
