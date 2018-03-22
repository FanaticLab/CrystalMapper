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

        public DbMemberExpression(MemberMetadata memberMetadata)
            : base(DbExpressionType.Member, memberMetadata.Member.GetMemberType() ?? memberMetadata.Member.DeclaringType)
        {
            this.MemberMetadata = memberMetadata;
        }    

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            if (!string.IsNullOrEmpty(this.TableAlias))
                queryWriter.Write(this.TableAlias).Write(".");

            queryWriter.Write(this.Type == null ? this.MemberMetadata.ColumnName : sqlLang.Wrap(this.MemberMetadata.ColumnName));
        }     
    }
}
