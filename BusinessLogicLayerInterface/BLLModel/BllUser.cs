using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterface.BLLModel
{
    public class BllUser: BllEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
