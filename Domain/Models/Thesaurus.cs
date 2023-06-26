using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Thesaurus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } = string.Empty;

        [Required]
        public string Line { get; set; } = string.Empty;

        [Required]
        public string Platform { get; set; } = string.Empty;

    }
}