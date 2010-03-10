using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Helper;
using System.Reflection;

namespace CrystalMapper.Linq.Expressions
{
    internal class DbMemberExpression : DbExpression
    {
        public string TableAlias { get; set; }

        public MemberMetadata MemberMetadata { get; private set; }

        public DbMemberExpression(MemberMetadata member)
            : base(DbExpressionType.Member, TypeHelper.GetMemberType(member.Member) ?? member.Member.DeclaringType)
        {
            this.MemberMetadata = member;
        }    

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            if (!string.IsNullOrEmpty(this.TableAlias))
                queryWriter.Write(this.TableAlias).Write(".");

            queryWriter.Write(FormatHelper.WrapInBrackets(this.MemberMetadata.ColumnName));
        }      
    }
}
