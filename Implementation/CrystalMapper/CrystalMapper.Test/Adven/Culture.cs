/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Culture
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
    public partial class Culture : Entity< Culture>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Culture";	
     
		public const string COL_CULTUREID = "CultureID";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CULTUREID = "@CultureID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CULTURE = "INSERT INTO Production.Culture([CultureID],[Name],[ModifiedDate]) VALUES (@CultureID,@Name,@ModifiedDate);";
		
		private const string SQL_UPDATE_CULTURE = "UPDATE Production.Culture SET [Name] = @Name, [ModifiedDate] = @ModifiedDate,  WHERE [CultureID] = @CultureID";
		
		private const string SQL_DELETE_CULTURE = "DELETE FROM Production.Culture WHERE  [CultureID] = @CultureID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CULTUREID, PARAM_CULTUREID )]
                              public virtual string CultureID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures
        {
            get {
                  foreach(ProductModelProductDescriptionCulture productModelProductDescriptionCulture in ProductModelProductDescriptionCultureList())
                    yield return productModelProductDescriptionCulture; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CultureID = (string)reader[COL_CULTUREID];
			this.Name = (string)reader[COL_NAME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CULTURE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CULTURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CULTURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public ProductModelProductDescriptionCulture GetProductModelProductDescriptionCulturesQuery()
        {
            return new ProductModelProductDescriptionCulture {                
                                                                            CultureID = this.CultureID  
                                                                            };
        }
        
        public ProductModelProductDescriptionCulture[] ProductModelProductDescriptionCultureList()
        {
            return GetProductModelProductDescriptionCulturesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
