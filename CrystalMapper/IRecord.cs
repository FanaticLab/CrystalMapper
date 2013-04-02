/****************************************************************
 * Author: Faraz Masood Khan 
 * Description: This interface provides CRUD database operations, 
 *              it should be implemented by all mapping classes
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using CrystalMapper.Context;

namespace CrystalMapper
{
    /// <summary>
    /// Interface for CRUD operations for single record
    /// </summary>
    public interface IRecord 
    {
        /// <summary>
        /// Database query provider used to load this record
        /// </summary>
        IQueryProvider Provider { get; set; }

        /// <summary>
        /// Load column values from data reader
        /// </summary>
        /// <param name="reader">Specific row to load data from</param>
        void Read(DbDataReader reader);

        /// <summary>
        /// Update a single record in database
        /// </summary>
        /// <param name="dataContext"></param>
        /// <returns>True if updates a single record</returns>
        bool Update(DataContext dataContext);

        /// <summary>
        /// Create a new record in database
        /// </summary>
        /// <param name="dataContext">Database connection</param>
        /// <returns>True if creates a single record</returns>
        bool Create(DataContext dataContext);

        /// <summary>
        /// Delete a single record in database
        /// </summary>
        /// <param name="dataContext">Database connection</param>
        /// <returns>True if deletes a single record</returns>
        bool Delete(DataContext dataContext);
    }
}
