using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Entities.Database;
using Entities.Query;

namespace BL {
    public class AppointmentManager {
        private readonly IDatabase<Appointment> _appointmentDB;

        public AppointmentManager(IDatabase<Appointment> appointmentDB) {
            _appointmentDB = appointmentDB;
        }

        public async Task<IList<Appointment>> GetAppointments(AppointmentParameters appointmentParams) {
            IList<Func<Appointment, bool>> conditions = new List<Func<Appointment, bool>>();

            if (appointmentParams.Available) {
                conditions.Add(a => a.StudentId == null);
            }

            if (appointmentParams.UserId != null) {
                conditions.Add(a => a.StudentId == appointmentParams.UserId || a.StudentId == appointmentParams.UserId);
            } else if (appointmentParams.TutorId != null) {
                conditions.Add(a => a.TutorId == appointmentParams.TutorId);
            } else if (appointmentParams.StudentId != null) {
                conditions.Add(a => a.StudentId == appointmentParams.StudentId);
            }

            return await _appointmentDB.Query(new() {
                Conditions = conditions,
                PageNumber = appointmentParams.PageNumber,
                PageSize = appointmentParams.PageSize,
                OrderBy = appointmentParams.OrderBy ?? "Date",
            });
        }

        public async Task<string> CancelAppointment(string appointmentId, string userId) {
            if (appointmentId == null) throw new ArgumentException("appointmentId is null");
            Appointment target = await _appointmentDB.FindSingle(new() {
                Conditions = new List<Func<Appointment, bool>> {
                    a => a.Id == appointmentId
                }
            });

            if (target == null) throw new ArgumentException("Appointment with the given Id could not be cancelled");

            if (target.TutorId == userId) {
                _appointmentDB.Delete(target);
            } else if (target.StudentId == userId){
                target.StudentId = null;
                target.Student = null;
                _appointmentDB.Save();
            } else {
                return "You are not authorized to cancel this appointment.";
            }

            return "The appointment was successfully cancelled.";
        }

        public async Task<Appointment> CreateAppointment(string tutorId, DateTime? date, int minuteLength) {
            if (tutorId == null || date == null) throw new ArgumentException("Appointment must have a TutorId and a date");

            Appointment newAppointment = new() {
                MinuteLength = minuteLength,
                Date = (DateTime) date,
                TutorId = tutorId
            };

            return await _appointmentDB.Create(newAppointment);
        }

        public async Task<Appointment> BookAppointment(string appointmentId, string userId) {
            if (appointmentId == null) throw new ArgumentException("appointmentId is null");
            Appointment target = await _appointmentDB.FindSingle(new() {
                Conditions = new List<Func<Appointment, bool>> {
                    a => a.Id == appointmentId
                }
            });

            if (target.StudentId == null) {
                target.StudentId = userId;
            } else {
                throw new ArgumentException("This appointment is not available");
            }

            return target;
        }
    }
}