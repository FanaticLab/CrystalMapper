using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Linq.Expressions;

namespace CrystalMapper.Linq
{
    internal class QueryInfo
    {
        public bool UseDefault { get; private set; }

        public string SqlQuery { get; set; }

        public ResultShape ResultShape { get; set; }

        public Type ReturnType { get; set; }

        public Dictionary<string, object> ParamValues { get; private set;}

        public ProjectionExpression Projection { get; private set; }

        public QueryInfo(ResultShape resultShape, bool useDefault, Type returnType, ProjectionExpression projection, string sqlQuery, Dictionary<string, object> paramValues )
        {
            this.UseDefault = useDefault;
            this.ReturnType = returnType;
            this.ResultShape = resultShape;
            this.SqlQuery = sqlQuery;
            this.ParamValues = paramValues;
            this.Projection = projection;
        }
    }
}
