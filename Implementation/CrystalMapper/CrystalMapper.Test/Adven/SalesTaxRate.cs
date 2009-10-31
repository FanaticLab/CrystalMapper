/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: SalesTaxRate
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
    public partial class SalesTaxRate : Entity< SalesTaxRate>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesTaxRate";	
     
		public const string COL_SALESTAXRATEID = "SalesTaxRateID";
		public const string COL_STATEPROVINCEID = "StateProvinceID";
		public const string COL_TAXTYPE = "TaxType";
		public const string COL_TAXRATE = "TaxRate";
		public const string COL_NAME = "Name";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESTAXRATEID = "@SalesTaxRateID";	
        public const string PARAM_STATEPROVINCEID = "@StateProvinceID";	
        public const string PARAM_TAXTYPE = "@TaxType";	
        public const string PARAM_TAXRATE = "@TaxRate";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESTAXRATE = "INSERT INTO Sales.SalesTaxRate([StateProvinceID],[TaxType],[TaxRate],[Name],[rowguid],[ModifiedDate]) VALUES (@StateProvinceID,@TaxType,@TaxRate,@Name,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESTAXRATE = "UPDATE Sales.SalesTaxRate SET [StateProvinceID] = @StateProvinceID, [TaxType] = @TaxType, [TaxRate] = @TaxRate, [Name] = @Name, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SalesTaxRateID] = @SalesTaxRateID";
		
		private const string SQL_DELETE_SALESTAXRATE = "DELETE FROM Sales.SalesTaxRate WHERE  [SalesTaxRateID] = @SalesTaxRateID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESTAXRATEID, PARAM_SALESTAXRATEID, default(int))]
                              public virtual int SalesTaxRateID  { get; set; }		
		
        
	    [Column( COL_STATEPROVINCEID, PARAM_STATEPROVINCEID, default(int))]
                              public virtual int StateProvinceID  { get; set; }	      
        
	    [Column( COL_TAXTYPE, PARAM_TAXTYPE, default(byte))]
                              public virtual byte TaxType  { get; set; }	      
        
	    [Column( COL_TAXRATE, PARAM_TAXRATE, typeof(decimal))]
                              public virtual decimal TaxRate  { get; set; }	      
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesTaxRateID = (int)reader[COL_SALESTAXRATEID];
			this.StateProvinceID = (int)reader[COL_STATEPROVINCEID];
			this.TaxType = (byte)reader[COL_TAXTYPE];
			this.TaxRate = (decimal)reader[COL_TAXRATE];
			this.Name = (string)reader[COL_NAME];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESTAXRATE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxType, PARAM_TAXTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxRate, PARAM_TAXRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.SalesTaxRateID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESTAXRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesTaxRateID, PARAM_SALESTAXRATEID));
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxType, PARAM_TAXTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxRate, PARAM_TAXRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESTAXRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesTaxRateID, PARAM_SALESTAXRATEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
