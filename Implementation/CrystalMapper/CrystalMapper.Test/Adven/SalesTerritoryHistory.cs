/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesTerritoryHistory
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 *
 * Website: http://www.linkedin.com/in/farazmasoodkhan
 *
 * Copyright: Faraz Masood Khan @ Copyright 2009
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace feedbook.Model
{
	[Table(TABLE_NAME)]
    public partial class SalesTerritoryHistory : Entity< SalesTerritoryHistory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesTerritoryHistory";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESTERRITORYHISTORY = "INSERT INTO Sales.SalesTerritoryHistory([BusinessEntityID],[TerritoryID],[StartDate],[EndDate],[rowguid],[ModifiedDate]) VALUES (@BusinessEntityID,@TerritoryID,@StartDate,@EndDate,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_SALESTERRITORYHISTORY = "UPDATE Sales.SalesTerritoryHistory SET  [EndDate] = @EndDate, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID AND [StartDate] = @StartDate AND [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_SALESTERRITORYHISTORY = "DELETE FROM Sales.SalesTerritoryHistory WHERE  [BusinessEntityID] = @BusinessEntityID AND [StartDate] = @StartDate AND [TerritoryID] = @TerritoryID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected int territoryid = default(int);
	
		protected System.DateTime startdate = default(System.DateTime);
	
		protected System.DateTime? enddate = default(System.DateTime?);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected SalesPerson salesPersonEntity;
	
		protected SalesTerritory salesTerritoryEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate 
        {
            get { return this.startdate; }
			set	{ 
                  if(this.startdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StartDate"));  
                        this.startdate = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StartDate"));
                    }   
                }
        }	
		
        [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate 
        {
            get { return this.enddate; }
			set	{ 
                  if(this.enddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EndDate"));  
                        this.enddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EndDate"));
                    }   
                }
        }	
		
        [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid 
        {
            get { return this.rowguid; }
			set	{ 
                  if(this.rowguid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rowguid"));  
                        this.rowguid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rowguid"));
                    }   
                }
        }	
		
        [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate 
        {
            get { return this.modifieddate; }
			set	{ 
                  if(this.modifieddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ModifiedDate"));  
                        this.modifieddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ModifiedDate"));
                    }   
                }
        }	
		
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.salesPersonEntity == null)
                    return this.businessentityid ;
                
                return this.salesPersonEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.salesPersonEntity = null;
                }                
            }          
        }	
        
        [Column( COL_TERRITORYID, PARAM_TERRITORYID, default(int))]
                              public virtual int TerritoryID                
        {
            get
            {
                if(this.salesTerritoryEntity == null)
                    return this.territoryid ;
                
                return this.salesTerritoryEntity.TerritoryID;            
            }
            set
            {
                if(this.territoryid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryID"));                    
                    this.territoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryID"));
                    
                    this.salesTerritoryEntity = null;
                }                
            }          
        }	
        
        public SalesPerson SalesPersonEntity
        {
            get { 
                    if(this.salesPersonEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        SalesPerson salesPersonQuery = new SalesPerson {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        SalesPerson[]  salesPeople = salesPersonQuery.ToList();                        
                        if(salesPeople.Length == 1)
                            this.salesPersonEntity = salesPeople[0];                        
                    }
                    
                    return this.salesPersonEntity; 
                }
			set	{ 
                  if(this.salesPersonEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesPersonEntity"));
                        if (this.salesPersonEntity != null)
                            this.Parents.Remove(this.salesPersonEntity);                            
                        
                        if((this.salesPersonEntity = value) != null) 
                            this.Parents.Add(this.salesPersonEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesPersonEntity"));
                        
                        this.businessentityid = this.SalesPersonEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public SalesTerritory SalesTerritoryEntity
        {
            get { 
                    if(this.salesTerritoryEntity == null
                       && this.territoryid != default(int)) 
                    {
                        SalesTerritory salesTerritoryQuery = new SalesTerritory {
                                                        TerritoryID = this.territoryid  
                                                        };
                        
                        SalesTerritory[]  salesTerritories = salesTerritoryQuery.ToList();                        
                        if(salesTerritories.Length == 1)
                            this.salesTerritoryEntity = salesTerritories[0];                        
                    }
                    
                    return this.salesTerritoryEntity; 
                }
			set	{ 
                  if(this.salesTerritoryEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesTerritoryEntity"));
                        if (this.salesTerritoryEntity != null)
                            this.Parents.Remove(this.salesTerritoryEntity);                            
                        
                        if((this.salesTerritoryEntity = value) != null) 
                            this.Parents.Add(this.salesTerritoryEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesTerritoryEntity"));
                        
                        this.territoryid = this.SalesTerritoryEntity.TerritoryID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public SalesTerritoryHistory()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                result = (11 * result) + this.startdate.GetHashCode();
                result = (11 * result) + this.territoryid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesTerritoryHistory entity = obj as SalesTerritoryHistory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.StartDate == entity.StartDate
                        && this.TerritoryID == entity.TerritoryID
                        && this.BusinessEntityID != default(int)
                        && this.StartDate != default(System.DateTime)
                        && this.TerritoryID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.territoryid = (int)reader[COL_TERRITORYID];
			this.startdate = (System.DateTime)reader[COL_STARTDATE];
			this.enddate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESTERRITORYHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESTERRITORYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESTERRITORYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));				
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
