using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;
using System.Linq.Expressions;

namespace CrystalMapper.Linq.Expressions
{
    internal class InExpression : DbBinaryExpression
    {
        public DbExpression Member { get { return this.Left; } }

        public SourceExpression Source { get { return (SourceExpression)this.Right; } }

        public InExpression(DbExpression member, SourceExpression source)
            : base(member, source, (ExpressionType)DbExpressionType.In, typeof(bool))
        {
            if (source is SelectExpression)
                ((SelectExpression)this.Source).WrapInBracks = false;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write("(");
            this.Member.WriteQuery(sqlLang, queryWriter);
            queryWriter.Write(" IN (");
            this.Source.WriteQuery(sqlLang, queryWriter);
            queryWriter.Write("))");
        }
    }
}
