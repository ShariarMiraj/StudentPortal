

using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class DiscussionForum
    {
        [Key]
        public int ForumID { get; set; }

        public string ForumName { get; set; }
        public string Description { get; set; }
        public  DateTime DateTime { get; set; }
        public string Creator { get; set; }

    }
}
