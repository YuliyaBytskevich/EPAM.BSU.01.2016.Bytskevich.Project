﻿using System.Collections.Generic;

namespace EFModel
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // navigation
        public virtual ICollection<User> Users { get; set; }
    }
}
