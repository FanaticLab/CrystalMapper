using CrystalMapper.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Test.Chinook
{
    public class ChinookDb : DbContext
    {
        public static readonly ChinookDb Context;

        static ChinookDb ()
        {
            Context = new ChinookDb();
        }
        
        public ChinookDb(): base("Chinook") { }
    }
}
