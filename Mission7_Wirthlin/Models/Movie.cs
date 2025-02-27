using System.ComponentModel.DataAnnotations;

namespace Mission7_Wirthlin.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Navigation property

        public string? Director { get; set; }
        public string? Rating { get; set; }
        public bool Edited { get; set; }
        public bool CopiedToPlex { get; set; }
        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}