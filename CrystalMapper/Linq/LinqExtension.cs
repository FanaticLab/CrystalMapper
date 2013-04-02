/**********************************
 * Author: Faraz Masood Khan 
 * Description: Extendening LINQ IQueryable through extension functions
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 **********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using CoreSystem.Dynamic;
using CrystalMapper.Context;
using CoreSystem.Util;

namespace CrystalMapper.Linq
{
    /// <summary>
    /// Constains extension functions for LINQ
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// Creates a queryable object using existing record query provider attached to the record
        /// </summary>
        /// <typeparam name="T">Type of querable</typeparam>
        /// <param name="record">Record to use query provider from</param>
        /// <returns>Queryable object</returns>
        public static IQueryable<T> CreateQuery<T>(this IRecord record)
        {
            Guard.CheckNull(record.Provider, "Record doesn't attached to a query provider, please reload record from database.");
            return new Query<T>(record.Provider as QueryProvider);
        }

        /// <summary>
        /// Read record with update lock in current DataContext; use same DataContext to update record
        /// </summary>
        /// <typeparam name="TSource">Type of record entity</typeparam>
        /// <param name="source">Query source</param>
        /// <returns>Record holding update lock in database</returns>
        public static TSource ForUpdate<TSource>(this IQueryable<TSource> source)
        {
            var forUpdate = (MethodInfo)MethodInfo.GetCurrentMethod();
#if NET40
            var expression = Expression.Call(null, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression);
#else
            var expression = Expression.Call(source.Expression, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression);
#endif
            return source.Provider.Execute<TSource>(expression);
        }

        /// <summary>
        /// Read record with update lock in current DataContext; use same DataContext to update record
        /// </summary>
        /// <typeparam name="TSource">Type of record entity</typeparam>
        /// <param name="source">Query source</param>
        /// <param name="predicate">Filter expression for record</param>
        /// <returns>Record holding update lock in database</returns>
        public static TSource ForUpdate<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            var forUpdate = (MethodInfo)MethodInfo.GetCurrentMethod();
#if NET40
            var expression = Expression.Call(null, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression, predicate);
#else
            var expression = Expression.Call(source.Expression, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression, predicate);
#endif
            return source.Provider.Execute<TSource>(expression);
        }

        /// <summary>
        /// Read records with update lock in current DataContext; use same DataContext to update record
        /// </summary>
        /// <typeparam name="TSource">Type of record entity</typeparam>
        /// <param name="source">Query source</param>
        /// <returns>Records holding update lock in database</returns>
        public static TSource[] ForUpdateAll<TSource>(this IQueryable<TSource> source)
        {
            var forUpdate = (MethodInfo)MethodInfo.GetCurrentMethod();
#if NET40
            var expression = Expression.Call(null, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression);
#else
            var expression = Expression.Call(source.Expression, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression);
#endif
            return source.Provider.Execute<TSource[]>(expression);
        }

        /// <summary>
        /// Read records with update lock in current DataContext; use same DataContext to update record
        /// </summary>
        /// <typeparam name="TSource">Type of record entity</typeparam>
        /// <param name="source">Query source</param>
        /// <param name="predicate">Filter expression for record</param>
        /// <returns>Records holding update lock in database</returns>
        public static List<TSource> ForUpdateAll<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            var forUpdate = (MethodInfo)MethodInfo.GetCurrentMethod();
#if NET40
            var expression = Expression.Call(null, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression, predicate);
#else
            var expression = Expression.Call(source.Expression, forUpdate.MakeGenericMethod(typeof(TSource)), source.Expression, predicate);
#endif
            return source.Provider.Execute<List<TSource>>(expression);
        }

        /// <summary>
        /// Return query result as dynamic objects
        /// </summary>
        /// <typeparam name="TSource">Type of record entity</typeparam>
        /// <param name="source">Query source</param>
        /// <returns>Dynamic objects</returns>
        public static List<Donymous> ToDonymous<TSource>(this IQueryable<TSource> source)
        {
            return source.Provider.Execute<List<Donymous>>(source.Expression);
        }
    }
}
