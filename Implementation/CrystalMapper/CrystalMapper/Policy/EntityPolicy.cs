using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Policy
{
    public abstract class EntityPolicy
    {
        public Type EntityType { get; private set; }

        public EntityPolicy(Type typeOfEntity)
        {
            this.EntityType = typeOfEntity;
        }
    }
}
