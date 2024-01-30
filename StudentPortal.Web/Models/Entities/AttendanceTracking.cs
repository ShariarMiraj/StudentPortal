using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class AttendanceTracking
    {
        [Key]
        public int AttendanceID { get; set; }



        public string Session { get; set; }
        public int StudentID { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime? LateArrivalTime { get; set; }
    }
}
