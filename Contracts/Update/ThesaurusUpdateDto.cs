using System.ComponentModel.DataAnnotations;

namespace Contracts.Update
{
    public class ThesaurusUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } = string.Empty;

        [Required]
        public string Line { get; set; } = string.Empty;

        [Required]
        public string Platform { get; set; } = string.Empty;
    }
}
