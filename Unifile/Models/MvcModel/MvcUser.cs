using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Unifile.Models.MvcModel
{
    public class MvcUser
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        //[Remote()]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}