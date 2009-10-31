/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: BillOfMaterial
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
    public partial class BillOfMaterial : Entity< BillOfMaterial>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.BillOfMaterials";	
     
		public const string COL_BILLOFMATERIALSID = "BillOfMaterialsID";
		public const string COL_PRODUCTASSEMBLYID = "ProductAssemblyID";
		public const string COL_COMPONENTID = "ComponentID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_UNITMEASURECODE = "UnitMeasureCode";
		public const string COL_BOMLEVEL = "BOMLevel";
		public const string COL_PERASSEMBLYQTY = "PerAssemblyQty";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BILLOFMATERIALSID = "@BillOfMaterialsID";	
        public const string PARAM_PRODUCTASSEMBLYID = "@ProductAssemblyID";	
        public const string PARAM_COMPONENTID = "@ComponentID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_UNITMEASURECODE = "@UnitMeasureCode";	
        public const string PARAM_BOMLEVEL = "@BOMLevel";	
        public const string PARAM_PERASSEMBLYQTY = "@PerAssemblyQty";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_BILLOFMATERIALS = "INSERT INTO Production.BillOfMaterials([ProductAssemblyID],[ComponentID],[StartDate],[EndDate],[UnitMeasureCode],[BOMLevel],[PerAssemblyQty],[ModifiedDate]) VALUES (@ProductAssemblyID,@ComponentID,@StartDate,@EndDate,@UnitMeasureCode,@BOMLevel,@PerAssemblyQty,@ModifiedDate);";
		
		private const string SQL_UPDATE_BILLOFMATERIALS = "UPDATE Production.BillOfMaterials SET [ProductAssemblyID] = @ProductAssemblyID, [ComponentID] = @ComponentID, [StartDate] = @StartDate, [EndDate] = @EndDate, [UnitMeasureCode] = @UnitMeasureCode, [BOMLevel] = @BOMLevel, [PerAssemblyQty] = @PerAssemblyQty, [ModifiedDate] = @ModifiedDate,  WHERE [BillOfMaterialsID] = @BillOfMaterialsID";
		
		private const string SQL_DELETE_BILLOFMATERIALS = "DELETE FROM Production.BillOfMaterials WHERE  [BillOfMaterialsID] = @BillOfMaterialsID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_BILLOFMATERIALSID, PARAM_BILLOFMATERIALSID, default(int))]
                              public virtual int BillOfMaterialsID  { get; set; }		
		
        
	    [Column( COL_PRODUCTASSEMBLYID, PARAM_PRODUCTASSEMBLYID )]
                              public virtual int? ProductAssemblyID  { get; set; }	      
        
	    [Column( COL_COMPONENTID, PARAM_COMPONENTID, default(int))]
                              public virtual int ComponentID  { get; set; }	      
        
	    [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate  { get; set; }	      
        
	    [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate  { get; set; }	      
        
	    [Column( COL_UNITMEASURECODE, PARAM_UNITMEASURECODE )]
                              public virtual string UnitMeasureCode  { get; set; }	      
        
	    [Column( COL_BOMLEVEL, PARAM_BOMLEVEL, default(short))]
                              public virtual short BOMLevel  { get; set; }	      
        
	    [Column( COL_PERASSEMBLYQTY, PARAM_PERASSEMBLYQTY, typeof(decimal))]
                              public virtual decimal PerAssemblyQty  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.BillOfMaterialsID = (int)reader[COL_BILLOFMATERIALSID];
			this.ProductAssemblyID = DbConvert.ToNullable< int >(reader[COL_PRODUCTASSEMBLYID]);
			this.ComponentID = (int)reader[COL_COMPONENTID];
			this.StartDate = (System.DateTime)reader[COL_STARTDATE];
			this.EndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.UnitMeasureCode = (string)reader[COL_UNITMEASURECODE];
			this.BOMLevel = (short)reader[COL_BOMLEVEL];
			this.PerAssemblyQty = (decimal)reader[COL_PERASSEMBLYQTY];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_BILLOFMATERIALS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductAssemblyID), PARAM_PRODUCTASSEMBLYID));
				command.Parameters.Add(dataContext.CreateParameter(this.ComponentID, PARAM_COMPONENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.BOMLevel, PARAM_BOMLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.PerAssemblyQty, PARAM_PERASSEMBLYQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.BillOfMaterialsID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_BILLOFMATERIALS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BillOfMaterialsID, PARAM_BILLOFMATERIALSID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductAssemblyID), PARAM_PRODUCTASSEMBLYID));
				command.Parameters.Add(dataContext.CreateParameter(this.ComponentID, PARAM_COMPONENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.BOMLevel, PARAM_BOMLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.PerAssemblyQty, PARAM_PERASSEMBLYQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_BILLOFMATERIALS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BillOfMaterialsID, PARAM_BILLOFMATERIALSID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
