using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BaselineAPI.Models
{
    public class NoteForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(5000)]
        public string Content {  get; set; } = string.Empty;
    }
}
