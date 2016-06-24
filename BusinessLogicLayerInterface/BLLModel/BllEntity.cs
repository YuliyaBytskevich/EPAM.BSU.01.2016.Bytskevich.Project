using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterface.BLLModel
{
    public abstract class BllEntity
    {

        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BllEntity;

            if (ReferenceEquals(compareTo, null))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (GetType() != compareTo.GetType())
                return false;

            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
                return true;

            return false;
        }

        public static bool operator ==(BllEntity a, BllEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BllEntity a, BllEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public virtual bool IsTransient()
        {
            return Id == 0;
        }
    }
}
