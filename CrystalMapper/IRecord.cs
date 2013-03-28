using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using CrystalMapper.Context;

namespace CrystalMapper
{
    public interface IRecord
    {
        void Read(DbDataReader reader);

        bool Update(DataContext dataContext);

        bool Create(DataContext dataContext);

        bool Delete(DataContext dataContext);
    }
}
