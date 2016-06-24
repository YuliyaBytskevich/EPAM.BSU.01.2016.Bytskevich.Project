using System.Collections.Generic;

namespace EFModel
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        // navigation
        public virtual Role Role { get; set; }
        public  virtual ICollection<CardMark> RelatedMarks { get; set; }
    }
}
