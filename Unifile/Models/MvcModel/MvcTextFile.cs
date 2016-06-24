using System.ComponentModel.DataAnnotations;

namespace Unifile.Models.MvcModel
{
    public class MvcTextFile: MvcAttachmentEntity
    {
        [Required]
        public string Author { get; set; }
    }
}