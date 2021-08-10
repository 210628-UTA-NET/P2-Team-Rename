using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using DL;
using Entities.Database;
using Entities.Query;
using NetTopologySuite;

namespace BL {
    public class TutorManager {
        private readonly IDatabase<Tutor> _tutorDB;
        private readonly IList<string> _includes;

        public TutorManager(IDatabase<Tutor> tutorDB) {
            _tutorDB = tutorDB;
            _includes = new List<string> {
                "TutorTopics",
                "TutorReviews",
                "MyStudents",
                "DegreesOrCerts"
            };
        }

        public async Task<IList<Tutor>> GetTutors(TutorParameters tutorParams) {
            IList<Func<Tutor, bool>> conditions = new List<Func<Tutor, bool>>();

            if (tutorParams.Name != null) {
                conditions.Add(t =>
                    t.FirstName.Contains(tutorParams.Name, StringComparison.OrdinalIgnoreCase)
                    || t.LastName.Contains(tutorParams.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (tutorParams.HourlyRate != null) {
                conditions.Add(t => t.HourlyRate < tutorParams.HourlyRate);
            }

            if (tutorParams.Rating != null) {
                conditions.Add(t => t.Rating > tutorParams.Rating);
            }

            if (tutorParams.Distance != null && tutorParams.Latitude != null && tutorParams.Longitude != null) {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var location = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate((double)tutorParams.Longitude, (double)tutorParams.Latitude));
                conditions.Add(t => t.Location.IsWithinDistance(location, (double)tutorParams.Distance));
            }

             return await _tutorDB.Query(new() {
                Conditions = conditions,
                Includes = _includes,
                PageNumber = tutorParams.PageNumber,
                PageSize = tutorParams.PageSize,
                OrderBy = tutorParams.OrderBy
            });
        }

        public async Task<Tutor> FindByIdAsync(string tutorId) {
            return await _tutorDB.FindSingle(new() {
                Conditions = new List<Func<Tutor, bool>> {
                    t => t.Id == tutorId
                },
                Includes = _includes
            });
        }

        public void SaveChanges() {
            _tutorDB.Save();
        }
    }
}
