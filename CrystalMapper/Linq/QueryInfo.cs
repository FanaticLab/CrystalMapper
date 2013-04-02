/**********************************************************************************
 * Author: Faraz Masood Khan 
 * Description: This class holds SQL query info after translating LINQ expressions
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 **********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Linq.Expressions;

namespace CrystalMapper.Linq
{
    /// <summary>
    /// Query info class for holding translated LINQ expression with SQL parameters
    /// </summary>
    internal class QueryInfo
    {
        /// <summary>
        /// User .NET default value for the return type if no result returned by query
        /// </summary>
        public bool UseDefault { get; private set; }

        /// <summary>
        /// Translated SQL query of LINQ expression
        /// </summary>
        public string SqlQuery { get; set; }

        /// <summary>
        /// Shape of the result return by query
        /// </summary>
        public ResultShape ResultShape { get; set; }

        /// <summary>
        /// Type of the result returned by query
        /// </summary>
        public Type ReturnType { get; set; }

        /// <summary>
        /// SQL parameters to be passed in SQLCommand when querying database
        /// </summary>
        public Dictionary<string, object> ParamValues { get; private set;}

        /// <summary>
        /// Projection expression to translate query result into expected result type
        /// </summary>
        public ProjectionExpression Projection { get; private set; }

        /// <summary>
        /// Creates a new QueryInfo for translated LINQ expression
        /// </summary>
        /// <param name="resultShape">Shape of the result return by query</param>
        /// <param name="useDefault">User .NET default value for the return type if no result returned by query</param>
        /// <param name="returnType">Type of the result returned by query</param>
        /// <param name="projection">Projection expression to translate query result into expected result type</param>
        /// <param name="sqlQuery">Translated SQL query of LINQ expression</param>
        /// <param name="paramValues">SQL parameters to be passed in SQLCommand when querying database</param>
        public QueryInfo(ResultShape resultShape, bool useDefault, Type returnType, ProjectionExpression projection, string sqlQuery, Dictionary<string, object> paramValues)
        {
            this.UseDefault = useDefault;
            this.ReturnType = returnType;
            this.ResultShape = resultShape;
            this.SqlQuery = sqlQuery;
            this.ParamValues = paramValues;
            this.Projection = projection;
        }
    }
}
