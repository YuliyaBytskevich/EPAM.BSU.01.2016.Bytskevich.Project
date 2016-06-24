using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IRoleService: IEntityService<BllRole>
    {
        void Create(string name, string description);

        BllRole GetRoleByName(string name);
    }
}
