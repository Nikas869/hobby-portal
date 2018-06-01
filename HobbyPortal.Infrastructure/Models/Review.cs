using System.ComponentModel.DataAnnotations;

namespace HobbyPortal.Infrastructure.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Rating { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int ClubId { get; set; }

        public Club Club { get; set; }
    }
}
