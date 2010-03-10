using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CrystalMapper.Linq.Expressions
{
    internal class MultiSourceExpression : SourceExpression
    {
        public ReadOnlyCollection<SourceExpression> Sources { get; private set; }

        public MultiSourceExpression(IEnumerable<SourceExpression> sources)
            : base(".", DbExpressionType.MultiSource, typeof(void))
        {
            this.Sources = new ReadOnlyCollection<SourceExpression>(sources.ToList());
        }

        public override void WriteQuery(Lang.SqlLang sqlLang, QueryWriter queryWriter)
        {
            bool isFirst = true;
            foreach (SourceExpression source in this.Sources)
            {
                if (!isFirst)
                    queryWriter.Write(", ");
                source.WriteQuery(sqlLang, queryWriter);

                isFirst = false;
            }
        }

        public override string GetAlias(Type type)
        {
            string alias;
            foreach (SourceExpression source in this.Sources)
                if (!string.IsNullOrEmpty(alias = source.GetAlias(type)))
                    return alias;

            return null;
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (SourceExpression source in this.Sources)
                foreach (DbExpression expression in source.GetNodes())
                    yield return expression;
        }
    }
}
