using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class DbBinaryExpression : DbExpression
    {
        public DbExpression Left { get; private set; }

        public DbExpression Right { get; private set; }

        public ExpressionType Operator { get; private set; }

        public DbBinaryExpression(DbExpression left, DbExpression right, ExpressionType binaryOperator, Type type)
            : base(DbExpressionType.Binary, type)
        {
            this.Left = left;
            this.Right = right;
            this.Operator = binaryOperator;
        }

        public DbBinaryExpression(DbExpression left, DbExpression right, BinaryExpression binaryExpression)
            : this(left, right, binaryExpression.NodeType, binaryExpression.Type)
        { }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write("(");

            this.Left.WriteQuery(sqlLang, queryWriter);

            queryWriter.Write(this.GetOperator());

            this.Right.WriteQuery(sqlLang, queryWriter);

            queryWriter.Write(")");
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (DbExpression expression in this.Left.GetNodes())
                yield return expression;

            foreach (DbExpression expression in this.Right.GetNodes())
                yield return expression;
        }

        public override object Clone()
        {
            DbExpression left = (Left != null) ? (DbExpression)Left.Clone() : null;
            DbExpression right = (Right != null) ? (DbExpression)Right.Clone() : null;
            
            return new DbBinaryExpression(left, right, this.Operator, this.Type);
        }      

        private string GetOperator()
        {
            switch (this.Operator)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    return (IsBoolean(this.Left.Type)) ? " AND " : " & ";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return (IsBoolean(this.Left.Type) ? " OR " : " | ");
                case ExpressionType.Equal:
                    if ((this.Left.DbNodeType == DbExpressionType.Parameter && ((DbParameterExpression)this.Left).IsDBNull)
                        || (this.Right.DbNodeType == DbExpressionType.Parameter && ((DbParameterExpression)this.Right).IsDBNull))
                        return " IS ";
                    return " = ";
                case ExpressionType.NotEqual:
                    if ((this.Left.DbNodeType == DbExpressionType.Parameter && ((DbParameterExpression)this.Left).IsDBNull)
                        || (this.Right.DbNodeType == DbExpressionType.Parameter && ((DbParameterExpression)this.Right).IsDBNull))
                        return " IS NOT ";
                    return " <> ";
                case ExpressionType.LessThan:
                    return " < ";
                case ExpressionType.LessThanOrEqual:
                    return " <= ";
                case ExpressionType.GreaterThan:
                    return " > ";
                case ExpressionType.GreaterThanOrEqual:
                    return " >= ";
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    return " + ";
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return " - ";
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    return " * ";
                case ExpressionType.Divide:
                    return " / ";
                case ExpressionType.Modulo:
                    return " % ";
                case ExpressionType.ExclusiveOr:
                    return "^";
                case ExpressionType.LeftShift:
                    return " << ";
                case ExpressionType.RightShift:
                    return " >> ";
                case (ExpressionType)DbExpressionType.Remainder:
                    return " % ";
                default:
                    return "";
            }
        }

        private bool IsBoolean(Type type)
        {
            return type == typeof(bool) || type == typeof(bool?);
        }        

        public static DbBinaryExpression RemainderExpression(DbExpression left, DbExpression right, Type type)
        {
            return new DbBinaryExpression(left, right, (ExpressionType)DbExpressionType.Remainder, type);
        }
    }
}
