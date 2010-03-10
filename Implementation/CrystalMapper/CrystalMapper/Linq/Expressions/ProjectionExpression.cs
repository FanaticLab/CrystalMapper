using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class ProjectionExpression : DbExpression
    {
        public ReadOnlyCollection<ColumnExpression> Columns { get; private set; }

        public Delegate ProjectionFunction { get; private set; }

        public ProjectionExpression(ReadOnlyCollection<ColumnExpression> columns, Type type, Delegate projectionFunction)
            : base(DbExpressionType.Projection, type)
        {
            this.Columns = columns;
            this.ProjectionFunction = projectionFunction;          
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            bool isFirst = true;
            foreach (var column in this.Columns)
            {
                if (!isFirst)
                    queryWriter.Write(", ");
                else
                    isFirst = false;

                column.WriteQuery(sqlLang, queryWriter);
            }
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (ColumnExpression column in this.Columns)
                foreach (DbExpression expression in column.GetNodes())
                    yield return expression;
        }
    }
}
