using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal enum JoinType
    {
        CrossJoin,
        InnerJoin,
        LeftOuterJoin
    }

    internal class JoinExpression : SourceExpression
    {
        public SourceExpression Outer { get; private set; }

        public SourceExpression Inner { get; private set; }

        public JoinType JoinType { get; private set; }

        public DbExpression Join { get; private set; }

        public ProjectionExpression Projection { get; private set; }

        public JoinExpression(SourceExpression outer, SourceExpression inner, JoinType joinType, DbExpression join, ProjectionExpression projection)
            : base(null, DbExpressionType.Join, projection.Type)
        {
            this.Outer = outer;
            this.Inner = inner;
            this.JoinType = joinType;
            this.Join = join;
            this.Projection = projection;

            this.AssignAlias();
        }

        public override string GetAlias(Type type)
        {
            string alias;
            return string.IsNullOrEmpty((alias = this.Outer.GetAlias(type))) ? this.Inner.GetAlias(type) : alias;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            this.Outer.WriteQuery(sqlLang, queryWriter);

            queryWriter.WriteLine();

            switch (this.JoinType)
            {
                case JoinType.CrossJoin:
                    queryWriter.Write("CROSS JOIN ");
                    break;
                case JoinType.InnerJoin:
                    queryWriter.Write("INNER JOIN ");
                    break;
                case JoinType.LeftOuterJoin:
                    queryWriter.Write("LEFT OUTER JOIN ");
                    break;
                default:
                    throw new InvalidOperationException(string.Format("Join '{0}' is not supported", this.JoinType));
            }

            this.Inner.WriteQuery(sqlLang, queryWriter);

            if (this.Join != null)
            {
                queryWriter.Write(" ON ");

                this.Join.WriteQuery(sqlLang, queryWriter);
            }
        }

        private void AssignAlias()
        {
            if (this.Join != null)
            {
                var dbMembers = this.Join.GetNodes().Where(e => e.DbNodeType == DbExpressionType.Member).Select(e => (DbMemberExpression)e).ToList();

                dbMembers.ForEach(e => e.TableAlias = this.GetAlias(e.MemberMetadata.Member.DeclaringType));
            }

            if (this.Projection != null)
            {
                var dbMembers = this.Projection.GetNodes().Where(e => e.DbNodeType == DbExpressionType.Member).Select(e => (DbMemberExpression)e).ToList();

                dbMembers.ForEach(e => e.TableAlias = this.GetAlias(e.MemberMetadata.Member.DeclaringType));
            }
        }
    }
}
