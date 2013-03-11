using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class DbUnaryExpression : IndirectExpression
    {
        public DbExpression Operand { get; private set; }

        public ExpressionType Operator { get; private set; }

        public DbUnaryExpression(DbExpression operand, ExpressionType unaryOperator, Type type)
            : base(operand, DbExpressionType.Unary, type)
        {
            this.Operand = operand;
            this.Operator = unaryOperator;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write(this.GetOperator());

            this.Operand.WriteQuery(sqlLang, queryWriter);
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (DbExpression expression in this.Operand.GetNodes())
                yield return expression;
        }

        public override object Clone()
        {
            DbExpression operand = (Operand != null) ? (DbExpression)Operand.Clone() : null;
            
            return new DbUnaryExpression(operand, this.Operator, this.Type);
        }      

        private string GetOperator()
        {
            switch (this.Operator)
            {
                case ExpressionType.Not:
                    return "NOT ";
                default:
                    return "";
            }
        }
    }
}
