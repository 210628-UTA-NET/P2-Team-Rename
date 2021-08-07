using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using Entities.Database;
using Entities.Query;
using Entities.Dtos;

namespace BL {
    public class TutorApplicationManager {
        private readonly IDatabase<TutorApplication> _applicationDB;
        private readonly IDatabase<Tutor> _tutorDB;
        private readonly IList<string> _includes;

        public TutorApplicationManager(IDatabase<TutorApplication> applicationDB, IDatabase<Tutor> tutorDB) {
            _applicationDB = applicationDB;
            _tutorDB = tutorDB;
            _includes = new List<string> {
                "User",
                "Topics",
                "DegreesOrCerts"
            };
        }

        public async Task<IList<TutorApplication>> GetTutorApplications(TutorAppParameters tutorAppParams) {
            IList<Func<TutorApplication, bool>> conditions = new List<Func<TutorApplication, bool>>();

            if (tutorAppParams.Open) {
                conditions.Add(app => app.Open == true);
            }

            return (await _applicationDB.Query(new() {
                Includes = _includes,
                Conditions = conditions,
                PageNumber = tutorAppParams.PageNumber,
                PageSize = tutorAppParams.PageSize,
                OrderBy = tutorAppParams.OrderBy ?? "Timestamp_desc"
            })); 
        }

        public async Task<TutorApplication> CreateTutorApplication(SubmitTutorApplicationDto applicationDto, string userId) {

            return await _applicationDB.Create(new TutorApplication() {
                UserId = userId,
                About = applicationDto.About,
                DegreesOrCerts = applicationDto.DegreesOrCerts,
                Open = true,
                Topics = applicationDto.Topics,
            }); 
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
                await _tutorDB.Create(new() {
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
