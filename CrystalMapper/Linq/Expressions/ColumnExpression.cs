using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Helper;

namespace CrystalMapper.Linq.Expressions
{
    internal class ColumnExpression : DbExpression
    {
        public MemberMetadata Member { get; private set; }

        public DbExpression Column { get; set; }

        public string ColumnAlias { get; private set; }

        public ColumnExpression(MemberMetadata member, DbExpression column, string columnAlias)
            : base(DbExpressionType.Column, column.Type)
        {
            this.Member = member;
            this.Column = column;
            this.ColumnAlias = columnAlias;        
        }

        public ColumnExpression(MemberMetadata member, DbExpression column)
            : this(member, column, null)
        { }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            this.Column.WriteQuery(sqlLang, queryWriter);

            if (!string.IsNullOrEmpty(this.ColumnAlias))
                queryWriter.Write(" AS ").Write(sqlLang.Wrap(this.ColumnAlias));
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (DbExpression expression in this.Column.GetNodes())
                yield return expression;
        }

        public override object Clone()
        {
            return new ColumnExpression(this.Member, (DbExpression)this.Column.Clone(), this.ColumnAlias);
        }
    }
}
