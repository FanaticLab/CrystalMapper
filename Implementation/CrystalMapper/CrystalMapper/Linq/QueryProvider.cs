using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CrystalMapper.Data;
using System.Data.Common;
using System.Collections;
using CrystalMapper.Linq.Translator;
using System.Data;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Helper;
using CoreSystem.Data;

namespace CrystalMapper.Linq
{
    public class QueryProvider : IQueryProvider
    {
        private string name;

        private bool disposeDataContext = false;
        
        private DataContext dataContext;

        private DataContext GetDataContext()
        {
            if (this.dataContext == null)
            {
                this.dataContext = string.IsNullOrEmpty(name) ? new DataContext() : new DataContext(name);
                this.disposeDataContext = true;
            }

            return this.dataContext;
        }

        public QueryProvider()
        { }

        public QueryProvider(string name)
        {
            this.name = name;
        }

        public QueryProvider(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        IQueryable<T> IQueryProvider.CreateQuery<T>(Expression expression)
        {
            return new Query<T>(this, expression);
        }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);

            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        T IQueryProvider.Execute<T>(Expression expression)
        {
            return (T)Execute(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return this.Execute(expression);
        }

        public object Execute(Expression expression)
        {
            DataContext dataContext = this.GetDataContext();           
            QueryInfo queryInfo = (new QueryTranslator()).Translate(this.GetSqlLangByProvider(), expression);
            
            try
            {                
                using (DbCommand command = dataContext.CreateCommand(queryInfo.SqlQuery))
                {
                    foreach (string parameter in queryInfo.ParamValues.Keys)
                        command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(queryInfo.ParamValues[parameter]), parameter));

                    if (queryInfo.ResultShape == ResultShape.None)
                        return command.ExecuteNonQuery();

                    if (queryInfo.ResultShape == ResultShape.Sequence)
                    {
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(new[] { queryInfo.ReturnType }));

                            foreach (object entity in queryInfo.Projection.Translate(queryInfo, reader))
                                list.Add(entity);

                            return list;
                        }
                    }

                    using (DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        foreach (object entity in queryInfo.Projection.Translate(queryInfo, reader))
                            return entity;

                        if (!queryInfo.UseDefault)
                            throw new InvalidOperationException("Query did not return any records");

                        return queryInfo.ReturnType.IsValueType ? Activator.CreateInstance(queryInfo.ReturnType) : null;
                    }
                }
            }
            finally
            {
                if (this.disposeDataContext && dataContext != null)
                    dataContext.Dispose();
            }
        }   

        private SqlLang GetSqlLangByProvider()
        {
            switch (this.GetDataContext().Database.ProviderType)
            {
                case CoreSystem.Data.DbProviderType.Oracle:
                    return SqlLang.GetSqlLang(SqlLangType.PSql);

                case CoreSystem.Data.DbProviderType.SqlServerCe:
                case CoreSystem.Data.DbProviderType.SqlServer:
                    return SqlLang.GetSqlLang(SqlLangType.TSql);

                case CoreSystem.Data.DbProviderType.SQLite:
                    return SqlLang.GetSqlLang(SqlLangType.Sqlite);
                
                case CoreSystem.Data.DbProviderType.UnSupported:
                default:
                    throw new NotSupportedException(string.Format("LINQ is not supported for Provider: '{0}'", this.GetDataContext().Database.DbProvider)); ;
            }
        }

        public string GetQuery(Expression expression)
        {
            return (new QueryTranslator()).Translate(this.GetSqlLangByProvider(), expression).SqlQuery;
        }
    }
}
