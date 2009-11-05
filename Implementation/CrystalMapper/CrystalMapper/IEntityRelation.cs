using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper
{
    public interface IEntityRelation<TEntity>
    {
        void Associate(TEntity child);

        void DeAssociate(TEntity child);

        TEntity[] GetChildren();
    }
}
