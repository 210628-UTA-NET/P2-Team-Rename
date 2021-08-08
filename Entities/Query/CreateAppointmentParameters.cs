using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Query {
    public class CreateAppointmentParameters {
        public DateTime? Date { get; set; }
        public int MinuteLength { get; set; }
    }
}