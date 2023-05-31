using System.ComponentModel.DataAnnotations;

namespace Entities.WEB.DataTransferObjects
{
    public class WordForUpdateDto
    {
        [Required(ErrorMessage = "WordName is required")]
        [StringLength(60, ErrorMessage = "WordName can't be longer than 60 characters")]
        public string? WordName { get; set; } //TODO: Make readonly.

        [Required(ErrorMessage = "Translation is required")]
        [StringLength(60, ErrorMessage = "Translation can't be longer than 60 characters")]
        public string? Translation { get; set; }
    }
}