using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DL;
using Entities.Database;
using Entities.Query;
using Microsoft.AspNetCore.Identity;

namespace BL {
    public class TutorApplicationManager {
        private readonly IDatabase<TutorApplication> _applicationDB;
        private readonly IDatabase<Tutor> _tutorDB;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IList<string> _includes;

        public TutorApplicationManager(IDatabase<TutorApplication> applicationDB, IDatabase<Tutor> tutorDB, UserManager<User> userManager, IMapper mapper) {
            _applicationDB = applicationDB;
            _tutorDB = tutorDB;
            _userManager = userManager;
            _mapper = mapper;
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

        public async Task<TutorApplication> CreateTutorApplication(TutorApplication application, string userId) {

            application.Open = true;
            application.UserId = userId;

            return await _applicationDB.Create(application); 
        }

        public async Task<bool> ApproveTutorApplication(string id, bool approve) {
            TutorApplication tutorApplication = await _applicationDB.FindSingle(new(){
                Includes = _includes,
                Conditions = new List<Func<TutorApplication, bool>>{
                    app => app.Id == id
                }
            });

            if (tutorApplication == null) throw new ArgumentException("No application with that Id could be found.");
            User user = await _userManager.FindByIdAsync(tutorApplication.UserId);
            if (tutorApplication == null) throw new ArgumentException("User associated with application could not be found.");

            if (approve) {
                Tutor tutor = _mapper.Map<User, Tutor>(user);
                tutor.DegreesOrCerts = tutorApplication.DegreesOrCerts;
                tutor.TutorTopics = tutorApplication.Topics;
                tutor.About = tutorApplication.About;

                await _userManager.DeleteAsync(user);
                await _tutorDB.Create(tutor);
                tutorApplication.UserId = tutor.Id;

                await _userManager.AddToRoleAsync(tutor, "Tutor");
            }

            // TO BE IMPLEMENTED
            // Send message to user telling them they have been approved or denied

            tutorApplication.Open = false;
            await _applicationDB.Save();
            return true;
        }
    }
}
