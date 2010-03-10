using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Linq.Metadata;

namespace CrystalMapper.Linq
{
    public class QueryInfo
    {
        public bool UseDefault { get; private set; }

        public string SqlQuery { get; set; }

        public ResultShape ResultShape { get; set; }

        public Type ReturnType { get; set; }

        public Dictionary<string, object> ParamValues { get; private set;}

        public QueryInfo(ResultShape resultShape, bool useDefault, Type returnType, string sqlQuery, Dictionary<string, object> paramValues )
        {
            this.UseDefault = useDefault;
            this.ReturnType = returnType;
            this.ResultShape = resultShape;
            this.SqlQuery = sqlQuery;
            this.ParamValues = paramValues;                       
        }
    }
}
