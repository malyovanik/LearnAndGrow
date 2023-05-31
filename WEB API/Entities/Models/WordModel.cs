using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.WEB.Models
{
    public enum EnumGeneration
    {
        Zero,
        First,
        Second
    }

    [Table("words")]
    public class WordModel
    {
        //public EnumGeneration Generation { get; private set; }

        [Key]
        public int WordId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? WordName { get; set; } //TODO: Make readonly.

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Translation { get; set; }
    }
}