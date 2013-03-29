using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CrystalMapper.Context;
using System.Data.Common;
using System.Collections;
using CrystalMapper.Linq.Translator;
using System.Data;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Helper;
using CoreSystem.Data;
using CoreSystem.Dynamic;
using CoreSystem.Util;

namespace CrystalMapper.Linq
{
    internal class QueryProvider : IQueryProvider
    {
        private string name;

        private bool disposeDataContext = false;

        private WeakReference dataContextRef;

        private DataContext GetDataContext()
        {
            DataContext dataContext;
            this.disposeDataContext = false;

            // Create a new data context (database connection) if:
            // a. Data context is not provided
            // b. It is beens collected by garbage collector
            // c. If object is disposed
            if (this.dataContextRef == null || (dataContext = this.dataContextRef.Target as DataContext) == null || dataContext.IsDisposed)
            {
                dataContext = new DataContext(name); // Creates a new database connection;
                this.disposeDataContext = true; // Dispose after querying database
            }

            return dataContext;
        }

        public QueryProvider(string name)
        {
            Guard.CheckNullOrWhiteSpace(name, "QueryProvider(name)");
            this.name = name;
        }

        public QueryProvider(DataContext dataContext)
        {
            Guard.CheckNull(dataContext, "QueryProvider(dataContext)");
            this.dataContextRef = new WeakReference(dataContext);
        }

        IQueryable<T> IQueryProvider.CreateQuery<T>(Expression expression)
        {
            return expression == null ? new Query<T>(this) : new Query<T>(this, expression);
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
            if (typeof(T) == typeof(List<Donymous>))
                return (T)ExecuteToDonymous(expression);

            return (T)Execute(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return this.Execute(expression);
        }

        public object Execute(Expression expression)
        {
            var queryInfo = (new QueryTranslator()).Translate(this.GetSqlLangByProvider(), expression);
            DataContext dataContext = this.GetDataContext();
            try
            {
                using (DbCommand command = dataContext.CreateCommand(queryInfo.SqlQuery))
                {
                    command.CommandTimeout = 120;
                    foreach (string parameter in queryInfo.ParamValues.Keys)
                        command.Parameters.Add(dataContext.CreateParameter(parameter, DbConvert.DbValue(queryInfo.ParamValues[parameter])));

                    if (queryInfo.ResultShape == ResultShape.None)
                        return command.ExecuteNonQuery();

                    if (queryInfo.ResultShape == ResultShape.Sequence)
                    {
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(new[] { queryInfo.ReturnType }));

                            if (typeof(IRecord).IsAssignableFrom(queryInfo.ReturnType))
                                foreach (IRecord record in queryInfo.Projection.Translate(queryInfo, reader))
                                {
                                    record.Provider = this;
                                    list.Add(record);
                                }

                            foreach (object record in queryInfo.Projection.Translate(queryInfo, reader))
                                list.Add(record);

                            return list;
                        }
                    }

                    using (DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        foreach (object entity in queryInfo.Projection.Translate(queryInfo, reader))
                        {
                            if (entity is IRecord)
                                ((IRecord)entity).Provider = this;

                            return entity;
                        }

                        if (!queryInfo.UseDefault)
                            throw new InvalidOperationException("Query did not return any records");

                        return queryInfo.ReturnType.IsValueType ? Activator.CreateInstance(queryInfo.ReturnType) : null;
                    }
                }
            }
            catch (DbException ex)
            {
                ex.Data.Add("SqlQuery", queryInfo.SqlQuery);
                throw ex;
            }
            finally
            {
                if (this.disposeDataContext && dataContext != null)
                    dataContext.Dispose();
            }
        }

        public string GetQuery(Expression expression)
        {
            return (new QueryTranslator()).Translate(this.GetSqlLangByProvider(), expression).SqlQuery;
        }

        private object ExecuteToDonymous(Expression expression)
        {
            var queryInfo = (new QueryTranslator()).Translate(this.GetSqlLangByProvider(), expression);
            DataContext dataContext = this.GetDataContext();
            try
            {
                using (DbCommand command = dataContext.CreateCommand(queryInfo.SqlQuery))
                {
                    command.CommandTimeout = 120;
                    foreach (string parameter in queryInfo.ParamValues.Keys)
                        command.Parameters.Add(dataContext.CreateParameter(parameter, DbConvert.DbValue(queryInfo.ParamValues[parameter])));

                    return DataContext.ToDonymous(command);
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

                case CoreSystem.Data.DbProviderType.MySql:
                    return SqlLang.GetSqlLang(SqlLangType.MySql);

                case CoreSystem.Data.DbProviderType.PostgreSQL:
                    return SqlLang.GetSqlLang(SqlLangType.PgSql);

                case CoreSystem.Data.DbProviderType.UnSupported:
                default:
                    throw new NotSupportedException(string.Format("LINQ is not supported for Provider: '{0}'", this.GetDataContext().Database.DbProvider)); ;
            }
        }
    }
}
