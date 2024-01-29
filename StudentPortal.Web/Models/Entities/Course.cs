namespace StudentPortal.Web.Models.Entities
{
    public class Course
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public  string  Department { get; set; }
        public string EnrolledStudents { get; set; }

    }
}
