using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterface.BLLModel
{
    public class BllRole: BllEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
