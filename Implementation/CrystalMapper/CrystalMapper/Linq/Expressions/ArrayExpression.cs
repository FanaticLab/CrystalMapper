using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CrystalMapper.Linq.Expressions
{
    internal class ArrayExpression : SourceExpression
    {
        private static readonly ReadOnlyCollection<ColumnExpression> EmptyColumns = (new List<ColumnExpression>()).AsReadOnly();

        public ReadOnlyCollection<DbParameterExpression> Parameters { get; private set; }

        public ArrayExpression(ReadOnlyCollection<DbParameterExpression> parameters, Type elementType)
            : base(null, new ProjectionExpression(EmptyColumns, elementType, null), DbExpressionType.Array, elementType)
        {
            this.Parameters = parameters;
        }

        public override string GetAlias(Type type)
        {
            return this.Alias;
        }

        public override void WriteQuery(CrystalMapper.Lang.SqlLang sqlLang, QueryWriter queryWriter)
        {
            bool isFirst = true;

            foreach (var parameter in this.Parameters)
            {
                if (!isFirst)
                    queryWriter.Write(", ");
                else
                    isFirst = false;

                parameter.WriteQuery(sqlLang, queryWriter);
            }
        }
    }
}
