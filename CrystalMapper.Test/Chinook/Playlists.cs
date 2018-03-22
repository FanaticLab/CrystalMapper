using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.Test.Chinook
{    
    public class Playlists
    { 
        public long PlaylistId { get; set; }
        
        public string Name { get; set; }

        public IQueryProvider Provider { get; set; }

        public bool Create(DataContext dataContext)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DataContext dataContext)
        {
            throw new NotImplementedException();
        }

        public void Read(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public bool Update(DataContext dataContext)
        {
            throw new NotImplementedException();
        }
    }
}
