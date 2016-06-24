using System.ComponentModel.DataAnnotations;

namespace Unifile.Models.MvcModel
{
    public abstract class MvcAttachmentEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Display (Name = "Title of related card")]
        [Required]
        public string CardTitle { get; set; }
    }
}