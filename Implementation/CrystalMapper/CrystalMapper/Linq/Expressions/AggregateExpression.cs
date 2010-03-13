using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;
using System.Collections.ObjectModel;

namespace CrystalMapper.Linq.Expressions
{
    internal class AggregateExpression : IndirectExpression
    {
        public string AggregateName { get { return this.DbNodeType.ToString(); } }

        public DbExpression Member { get; private set; }

        public AggregateExpression(DbExpression source, DbExpression member, DbExpressionType aggregateType, Type type)
            : base(source, aggregateType, type)
        {
            this.Member = member;
            if (this.Member == null)
            {
                while (!(source is TableExpression) && !(source is SelectExpression))
                {
                    IndirectExpression indirectExpression = source as IndirectExpression;

                    if (indirectExpression == null)
                        throw new InvalidOperationException(string.Format("Unable to find source expression: '{0}'", source));

                    source = indirectExpression.Source;
                }

                if (source is SelectExpression)
                    this.Member = new DbMemberExpression(((SelectExpression)source).Projection.Columns.First().Member);
            }
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            if (!sqlLang.IsAggregateSupportted(this.AggregateName))
                throw new NotSupportedException(string.Format("{0} language does not support aggregate function: {1}", sqlLang.SqlLangType, this.AggregateName));

            queryWriter.Write(sqlLang.SqlAggregateName(this.AggregateName));
            queryWriter.Write("(");
            if (this.Member == null)
            {
                if (!sqlLang.AggregateArgumentIsPredicate(this.AggregateName))
                    throw new InvalidOperationException(string.Format("Columns must be select in order to calculate aggregate: '{0}'", this.AggregateName));

                queryWriter.Write("*");
            }
            else
            {
                this.Member.WriteQuery(sqlLang, queryWriter);
            }
            queryWriter.Write(") ");
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            if (this.Member != null)
                foreach (DbExpression expression in this.Member.GetNodes())
                    yield return expression;
        }
    }
}
