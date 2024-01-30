namespace StudentPortal.Web.Models
{
    public class AttendanceTrackingViewModel
    {
        public int AttendanceID { get; set; }



        public string Session { get; set; }
        public int StudentID { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime? LateArrivalTime { get; set; }
    }
}
