/*******************************************************
 * Author: Faraz Masood Khan 
 * Description: Implements IQueryable for CrystalMapper
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 *******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;
using CrystalMapper.Context;
using System.Data.Common;
using CoreSystem.Util;

namespace CrystalMapper.Linq
{
    /// <summary>
    /// Queryable object for CrystalMapper 
    /// </summary>
    /// <typeparam name="T">Type of querable object</typeparam>
    internal class Query<T> : IQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable, IOrderedQueryable<T>, IOrderedQueryable
    {
        QueryProvider provider;
        Expression expression;

        public Query(string name)
            : this(new QueryProvider(name))
        { }

        public Query(DataContext dataContext)
            : this(new QueryProvider(dataContext))
        { }

        public Query(QueryProvider provider)
        {
            Guard.CheckNull(provider, "Query(provider)");

            this.provider = provider;
            this.expression = Expression.Constant(this);
        }

        public Query(QueryProvider provider, Expression expression)
        {
            Guard.CheckNull(provider, "Query(provider)");
            Guard.CheckNull(expression, "Query(expression)");

            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
                throw new ArgumentOutOfRangeException("expression");

            this.provider = provider;
            this.expression = expression;
        }

        Expression IQueryable.Expression
        {
            get { return this.expression; }
        }

        Type IQueryable.ElementType
        {
            get { return typeof(T); }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return this.provider; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.provider.Execute(this.expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.provider.Execute(this.expression)).GetEnumerator();
        }

        public override string ToString()
        {
            return this.provider.GetQuery(this.expression);
        }
    }

}
