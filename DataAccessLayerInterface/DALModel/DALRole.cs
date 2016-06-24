using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterface.DALModel
{
    public class DalRole: DalEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
