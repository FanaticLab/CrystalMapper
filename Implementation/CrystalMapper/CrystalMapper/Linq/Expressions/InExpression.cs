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

        public SelectExpression Select { get { return (SelectExpression)this.Right; } }

        public InExpression(DbExpression member, SelectExpression select)
            : base(member, select, (ExpressionType)DbExpressionType.In, typeof(bool))
        {
            this.Select.WrapInBracks = false;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write("(");
            this.Member.WriteQuery(sqlLang, queryWriter);
            queryWriter.Write(" IN (");
            this.Select.WriteQuery(sqlLang, queryWriter);
            queryWriter.Write("))");
        }
    }
}
