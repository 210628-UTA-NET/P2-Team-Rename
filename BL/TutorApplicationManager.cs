using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using DL.Entities;

namespace BL {
    public class TutorApplicationManager {
        private readonly IDatabase<TutorApplication> _applicationDB;
        private readonly IList<string> _includes;

        public TutorApplicationManager(IDatabase<TutorApplication> applicationDB) {
            _applicationDB = applicationDB;
            _includes = new List<string> {
                "Tutor",
                "Tutor.User",
                "Tutor.DegreesOrCerts"
            };
        }

        public async Task<IList<TutorApplication>> GetTutorApplications(bool openOnly = true) {
            IList<Func<TutorApplication, bool>> conditions = new List<Func<TutorApplication, bool>>();

            if (openOnly) {
                conditions.Add(app => app.Open == true);
            }

            return (await _applicationDB.Query(new() {
                Includes = _includes,
                Conditions = conditions
            })).OrderByDescending(app => app.Timestamp).ToList(); 
        }
    }
}
