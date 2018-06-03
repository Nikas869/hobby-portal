using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyPortal.Infrastructure.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [NotMapped]
        public DayOfWeek[] Recurrence
        {
            get { return RecurrenceConfig == null ? new DayOfWeek[0] : JsonConvert.DeserializeObject<DayOfWeek[]>(RecurrenceConfig); }
            set { RecurrenceConfig = JsonConvert.SerializeObject(value); }
        }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public string RecurrenceConfig { get; private set; }
    }
}
