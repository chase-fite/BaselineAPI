using System.ComponentModel.DataAnnotations;

namespace BaselineAPI.Models
{
    public class NoteForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(5000)]
        public string Content {  get; set; } = string.Empty;
    }
}
