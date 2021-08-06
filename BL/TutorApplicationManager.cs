using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using DL.Entities;

namespace BL {
    public class TutorApplicationManager {
        private readonly IDatabase<TutorApplication> _applicationDB;
        private readonly IDatabase<Tutor> _tutorDB;
        private readonly IList<string> _includes;

        public TutorApplicationManager(IDatabase<TutorApplication> applicationDB, IDatabase<Tutor> tutorDB) {
            _applicationDB = applicationDB;
            _tutorDB = tutorDB;
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

        public async void ApproveTutorApplication(string id, bool approve) {
            TutorApplication tutorApplication = await _applicationDB.FindSingle(new(){
                Includes = _includes,
                Conditions = new List<Func<TutorApplication, bool>>{
                    app => app.Id == id
                }
            });

            if (tutorApplication == null) throw new ArgumentException("No application with that Id could be found.");

            if (approve) {
                _tutorDB.Create(new() {
                    UserAccountId = tutorApplication.UserId,
                    DegreesOrCerts = tutorApplication.DegreesOrCerts,
                    Topics = tutorApplication.Topics,
                    About = tutorApplication.About
                });
            }

            // TO BE IMPLEMENTED
            // Send message to user telling them they have been approved or denied

            tutorApplication.Open = false;
            _applicationDB.Save();
        }
    }
}
