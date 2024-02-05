using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Totalpages { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int GenerId { get; set; }
    }
}
