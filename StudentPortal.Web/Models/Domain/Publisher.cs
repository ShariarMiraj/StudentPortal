using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Domain
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
