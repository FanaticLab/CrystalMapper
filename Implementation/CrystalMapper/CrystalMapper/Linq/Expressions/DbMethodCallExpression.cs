using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;
using System.Reflection;
using System.Collections.ObjectModel;

namespace CrystalMapper.Linq.Expressions
{
    internal class DbMethodCallExpression : DbExpression
    {
        public DbExpression Object { get; set; }

        public MethodInfo Method { get; private set; }

        public ReadOnlyCollection<DbExpression> Arguments { get; private set; }

        public DbMethodCallExpression(DbExpression obj, MethodInfo method, IEnumerable<DbExpression> arguments)
            :base(DbExpressionType.Method, method.ReturnType)
        {
            this.Object = obj;
            this.Method = method;
            this.Arguments = arguments.ToReadOnly();
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            switch (sqlLang.SqlLangType)
            {
                case SqlLangType.TSql:
                    this.WriteTSql(sqlLang, queryWriter);
                    return;
                case SqlLangType.Sqlite:                   
                case SqlLangType.PSql:
                default:
                    throw new NotSupportedException(string.Format("Sql language: '{0}' is not supported yet", sqlLang.SqlLangType));
            }
        }

        private void WriteTSql(SqlLang sqlLang, QueryWriter queryWriter)
        {
            if (this.Method.DeclaringType == typeof(string))
            {
               switch (this.Method.Name)
                {
                    case "StartsWith":
                        queryWriter.Write("(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" LIKE ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" + '%')");
                        return;
                    case "EndsWith":
                        queryWriter.Write("(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" LIKE '%' + ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Contains":
                        queryWriter.Write("(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" LIKE '%' + ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" + '%')");
                        return;
                    //case "Concat":                       
                        //IList<Expression> args = m.Arguments;
                        //if (args.Count == 1 && args[0].NodeType == ExpressionType.NewArrayInit)
                        //{
                        //    args = ((NewArrayExpression)args[0]).Expressions;
                        //}
                        //for (int i = 0, n = args.Count; i < n; i++)
                        //{
                        //    if (i > 0) queryWriter.Write(" + ");
                        //    this.Visit(args[i]);
                        //}
                        //return m;
                    case "IsNullOrEmpty":
                        queryWriter.Write("(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" IS NULL OR ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" = '')");
                        return;
                    case "ToUpper":
                        queryWriter.Write("UPPER(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "ToLower":
                        queryWriter.Write("LOWER(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Replace":
                        queryWriter.Write("REPLACE(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Substring":
                        queryWriter.Write("SUBSTRING(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" + 1, ");
                        if (this.Arguments.Count == 2)
                        {
                            this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                        }
                        else
                        {
                            queryWriter.Write("8000");
                        }
                        queryWriter.Write(")");
                        return;
                    case "Remove":
                        queryWriter.Write("STUFF(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" + 1, ");
                        if (this.Arguments.Count == 2)
                        {
                            this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                        }
                        else
                        {
                            queryWriter.Write("8000");
                        }
                        queryWriter.Write(", '')");
                        return;
                    case "IndexOf":
                        queryWriter.Write("(CHARINDEX(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        if (this.Arguments.Count == 2 && this.Arguments[1].Type == typeof(int))
                        {
                            queryWriter.Write(", ");
                            this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(" + 1");
                        }
                        queryWriter.Write(") - 1)");
                        return;
                    case "Trim":
                        queryWriter.Write("RTRIM(LTRIM(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write("))");
                        return;
                    case "TrimStart":
                        queryWriter.Write("LTRIM(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "TrimEnd":
                        queryWriter.Write("RTRIM(");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                }
            }
            else if (this.Method.DeclaringType == typeof(DateTime))
            {
                switch (this.Method.Name)
                {
                    case "op_Subtract":
                        if (this.Arguments[1].Type == typeof(DateTime))
                        {
                            queryWriter.Write("DATEDIFF(");
                            this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(", ");
                            this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(")");
                            return;
                        }
                        break;
                    case "AddYears":
                        queryWriter.Write("DATEADD(YYYY,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "AddMonths":
                        queryWriter.Write("DATEADD(MM,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "AddDays":
                        queryWriter.Write("DATEADD(DAY,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "AddHours":
                        queryWriter.Write("DATEADD(HH,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "AddMinutes":
                        queryWriter.Write("DATEADD(MI,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "AddSeconds":
                        queryWriter.Write("DATEADD(SS,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "AddMilliseconds":
                        queryWriter.Write("DATEADD(MS,");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(",");
                        this.Object.WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                }
            }
            else if (this.Method.DeclaringType == typeof(Decimal))
            {
                switch (this.Method.Name)
                {
                    case "Add":
                    case "Subtract":
                    case "Multiply":
                    case "Divide":
                    case "Remainder":
                        queryWriter.Write("(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(" ");
                        queryWriter.Write(GetOperator(this.Method.Name));
                        queryWriter.Write(" ");
                        this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Negate":
                        queryWriter.Write("-");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write("");
                        return;
                    case "Ceiling":
                    case "Floor":
                        queryWriter.Write(this.Method.Name.ToUpper());
                        queryWriter.Write("(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Round":
                        if (this.Arguments.Count == 1)
                        {
                            queryWriter.Write("ROUND(");
                            this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(", 0)");                            
                        }
                        else if (this.Arguments.Count == 2 && this.Arguments[1].Type == typeof(int))
                        {
                            queryWriter.Write("ROUND(");
                            this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(", ");
                            this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(")");                            
                        }
                        return;
                    case "Truncate":
                        queryWriter.Write("ROUND(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", 0, 1)");
                        return;
                }
            }
            else if (this.Method.DeclaringType == typeof(Math))
            {
                switch (this.Method.Name)
                {
                    case "Abs":
                    case "Acos":
                    case "Asin":
                    case "Atan":
                    case "Cos":
                    case "Exp":
                    case "Log10":
                    case "Sin":
                    case "Tan":
                    case "Sqrt":
                    case "Sign":
                    case "Ceiling":
                    case "Floor":
                        queryWriter.Write(this.Method.Name.ToUpper());
                        queryWriter.Write("(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Atan2":
                        queryWriter.Write("ATN2(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Log":
                        if (this.Arguments.Count == 1)
                        {
                            goto case "Log10";
                        }
                        return;
                    case "Pow":
                        queryWriter.Write("POWER(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", ");
                        this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(")");
                        return;
                    case "Round":
                        if (this.Arguments.Count == 1)
                        {
                            queryWriter.Write("ROUND(");
                            this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(", 0)");
                            return;
                        }
                        else if (this.Arguments.Count == 2 && this.Arguments[1].Type == typeof(int))
                        {
                            queryWriter.Write("ROUND(");
                            this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(", ");
                            this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                            queryWriter.Write(")");
                            return;
                        }
                        break;
                    case "Truncate":
                        queryWriter.Write("ROUND(");
                        this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                        queryWriter.Write(", 0, 1)");
                        return;
                }
            }
            if (this.Method.Name == "ToString")
            {
                if (this.Object.Type != typeof(string))
                {
                    queryWriter.Write("CONVERT(NVARCHAR, ");
                    this.Object.WriteQuery(sqlLang, queryWriter);
                    queryWriter.Write(")");
                }
                else
                {
                    this.Object.WriteQuery(sqlLang, queryWriter);
                }
                return;
            }
            else if (!this.Method.IsStatic && this.Method.Name == "CompareTo" && this.Method.ReturnType == typeof(int) && this.Arguments.Count == 1)
            {
                queryWriter.Write("(CASE WHEN ");
                this.Object.WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" = ");
                this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" THEN 0 WHEN ");
                this.Object.WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" < ");
                this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" THEN -1 ELSE 1 END)");
                return;
            }
            else if (this.Method.IsStatic && this.Method.Name == "Compare" && this.Method.ReturnType == typeof(int) && this.Arguments.Count == 2)
            {
                queryWriter.Write("(CASE WHEN ");
                this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" = ");
                this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" THEN 0 WHEN ");
                this.Arguments[0].WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" < ");
                this.Arguments[1].WriteQuery(sqlLang, queryWriter);
                queryWriter.Write(" THEN -1 ELSE 1 END)");
                return;
            }

            throw new NotSupportedException(string.Format("Failed to translate method: '{0}' into sql", this.Method));
        }

        private static string GetOperator(string methodName)
        {
            switch (methodName)
            {
                case "Add": return "+";
                case "Subtract": return "-";
                case "Multiply": return "*";
                case "Divide": return "/";
                case "Negate": return "-";
                case "Remainder": return "%";
                default: return null;
            }
        }
    }
}
