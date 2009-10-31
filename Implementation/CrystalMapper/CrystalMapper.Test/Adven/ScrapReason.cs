/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ScrapReason
 *    
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace CrystalMapper.Generated.BusinessObjects
{
    [Table(TABLE_NAME)]
    public partial class ScrapReason : Entity<ScrapReason>
    {
        #region Table Schema

        public const string TABLE_NAME = "Production.ScrapReason";

        public const string COL_SCRAPREASONID = "ScrapReasonID";
        public const string COL_NAME = "Name";
        public const string COL_MODIFIEDDATE = "ModifiedDate";

        public const string PARAM_SCRAPREASONID = "@ScrapReasonID";
        public const string PARAM_NAME = "@Name";
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";

        #endregion

        #region Queries

        private const string SQL_INSERT_SCRAPREASON = "INSERT INTO Production.ScrapReason([Name],[ModifiedDate]) VALUES (@Name,@ModifiedDate);";

        private const string SQL_UPDATE_SCRAPREASON = "UPDATE Production.ScrapReason SET [Name] = @Name, [ModifiedDate] = @ModifiedDate,  WHERE [ScrapReasonID] = @ScrapReasonID";

        private const string SQL_DELETE_SCRAPREASON = "DELETE FROM Production.ScrapReason WHERE  [ScrapReasonID] = @ScrapReasonID ";

        #endregion
        #region Properties

        [Column(COL_SCRAPREASONID, PARAM_SCRAPREASONID, default(short))]
        public virtual short ScrapReasonID { get; set; }


        [Column(COL_NAME, PARAM_NAME)]
        public virtual string Name { get; set; }

        [Column(COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
        public virtual System.DateTime ModifiedDate { get; set; }

        public IEnumerable<WorkOrder> WorkOrders
        {
            get
            {
                foreach (WorkOrder workOrder in WorkOrderList())
                    yield return workOrder;
            }
        }


        #endregion


        #region Methods

        public override void Read(DbDataReader reader)
        {
            this.ScrapReasonID = (short)reader[COL_SCRAPREASONID];
            this.Name = (string)reader[COL_NAME];
            this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
        }

        public override bool Create(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_INSERT_SCRAPREASON))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
                command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if (command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ScrapReasonID = Convert.ToInt16(command.ExecuteScalar());
                    return true;
                }
                return false;
            }
        }

        public override bool Update(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_UPDATE_SCRAPREASON))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.ScrapReasonID, PARAM_SCRAPREASONID));
                command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
                command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));

                return (command.ExecuteNonQuery() == 1);
            }
        }

        public override bool Delete(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_DELETE_SCRAPREASON))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.ScrapReasonID, PARAM_SCRAPREASONID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion

        #region Children

        public WorkOrder GetWorkOrdersQuery()
        {
            return new WorkOrder
            {
                ScrapReasonID = this.ScrapReasonID
            };
        }

        public WorkOrder[] WorkOrderList()
        {
            return GetWorkOrdersQuery().ToList();
        }




        #endregion
    }
}
