/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesPerson
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
    public partial class SalesPerson : Entity< SalesPerson>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesPerson";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_SALESQUOTA = "SalesQuota";
		public const string COL_BONUS = "Bonus";
		public const string COL_COMMISSIONPCT = "CommissionPct";
		public const string COL_SALESYTD = "SalesYTD";
		public const string COL_SALESLASTYEAR = "SalesLastYear";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_SALESQUOTA = "@SalesQuota";	
        public const string PARAM_BONUS = "@Bonus";	
        public const string PARAM_COMMISSIONPCT = "@CommissionPct";	
        public const string PARAM_SALESYTD = "@SalesYTD";	
        public const string PARAM_SALESLASTYEAR = "@SalesLastYear";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESPERSON = "INSERT INTO Sales.SalesPerson([BusinessEntityID],[TerritoryID],[SalesQuota],[Bonus],[CommissionPct],[SalesYTD],[SalesLastYear],[rowguid],[ModifiedDate]) VALUES (@BusinessEntityID,@TerritoryID,@SalesQuota,@Bonus,@CommissionPct,@SalesYTD,@SalesLastYear,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_SALESPERSON = "UPDATE Sales.SalesPerson SET  [TerritoryID] = @TerritoryID, [SalesQuota] = @SalesQuota, [Bonus] = @Bonus, [CommissionPct] = @CommissionPct, [SalesYTD] = @SalesYTD, [SalesLastYear] = @SalesLastYear, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID";
		
		private const string SQL_DELETE_SALESPERSON = "DELETE FROM Sales.SalesPerson WHERE  [BusinessEntityID] = @BusinessEntityID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected int? territoryid = default(int?);
	
		protected decimal? salesquotum = default(decimal?);
	
		protected decimal bonu = default(decimal);
	
		protected decimal commissionpct = default(decimal);
	
		protected decimal salesytd = default(decimal);
	
		protected decimal saleslastyear = default(decimal);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Employee employeeEntity;
	
		protected SalesTerritory salesTerritoryEntity;
	
        protected EntityCollection< SalesOrderHeader> salesOrderHeaders ;
        
        protected EntityCollection< SalesPersonQuotaHistory> salesPersonQuotaHistories ;
        
        protected EntityCollection< SalesTerritoryHistory> salesTerritoryHistories ;
        
        protected EntityCollection< Store> stores ;
        
        #endregion

 		#region Properties	

        [Column( COL_SALESQUOTA, PARAM_SALESQUOTA )]
                              public virtual decimal? SalesQuota 
        {
            get { return this.salesquotum; }
			set	{ 
                  if(this.salesquotum != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesQuota"));  
                        this.salesquotum = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesQuota"));
                    }   
                }
        }	
		
        [Column( COL_BONUS, PARAM_BONUS, typeof(decimal))]
                              public virtual decimal Bonus 
        {
            get { return this.bonu; }
			set	{ 
                  if(this.bonu != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Bonus"));  
                        this.bonu = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Bonus"));
                    }   
                }
        }	
		
        [Column( COL_COMMISSIONPCT, PARAM_COMMISSIONPCT, typeof(decimal))]
                              public virtual decimal CommissionPct 
        {
            get { return this.commissionpct; }
			set	{ 
                  if(this.commissionpct != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CommissionPct"));  
                        this.commissionpct = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CommissionPct"));
                    }   
                }
        }	
		
        [Column( COL_SALESYTD, PARAM_SALESYTD, typeof(decimal))]
                              public virtual decimal SalesYTD 
        {
            get { return this.salesytd; }
			set	{ 
                  if(this.salesytd != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesYTD"));  
                        this.salesytd = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesYTD"));
                    }   
                }
        }	
		
        [Column( COL_SALESLASTYEAR, PARAM_SALESLASTYEAR, typeof(decimal))]
                              public virtual decimal SalesLastYear 
        {
            get { return this.saleslastyear; }
			set	{ 
                  if(this.saleslastyear != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesLastYear"));  
                        this.saleslastyear = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesLastYear"));
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
                if(this.employeeEntity == null)
                    return this.businessentityid ;
                
                return this.employeeEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.employeeEntity = null;
                }                
            }          
        }	
        
        [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual int? TerritoryID                
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
        
        public Employee EmployeeEntity
        {
            get { 
                    if(this.employeeEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        Employee employeeQuery = new Employee {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        Employee[]  employees = employeeQuery.ToList();                        
                        if(employees.Length == 1)
                            this.employeeEntity = employees[0];                        
                    }
                    
                    return this.employeeEntity; 
                }
			set	{ 
                  if(this.employeeEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeEntity"));
                        if (this.employeeEntity != null)
                            this.Parents.Remove(this.employeeEntity);                            
                        
                        if((this.employeeEntity = value) != null) 
                            this.Parents.Add(this.employeeEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeEntity"));
                        
                        this.businessentityid = this.EmployeeEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public SalesTerritory SalesTerritoryEntity
        {
            get { 
                    if(this.salesTerritoryEntity == null
                       && this.territoryid.HasValue )
                    {
                        SalesTerritory salesTerritoryQuery = new SalesTerritory {
                                                        TerritoryID = this.territoryid.Value  
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
		
        public EntityCollection< SalesOrderHeader> SalesOrderHeaders 
        {
            get { return this.salesOrderHeaders;}
        }
        
        public EntityCollection< SalesPersonQuotaHistory> SalesPersonQuotaHistories 
        {
            get { return this.salesPersonQuotaHistories;}
        }
        
        public EntityCollection< SalesTerritoryHistory> SalesTerritoryHistories 
        {
            get { return this.salesTerritoryHistories;}
        }
        
        public EntityCollection< Store> Stores 
        {
            get { return this.stores;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public SalesPerson()
        {
             this.salesOrderHeaders = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaders), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaders), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaders));
             this.salesPersonQuotaHistories = new EntityCollection< SalesPersonQuotaHistory>(this, new Associate< SalesPersonQuotaHistory>(this.AssociateSalesPersonQuotaHistories), new DeAssociate< SalesPersonQuotaHistory>(this.DeAssociateSalesPersonQuotaHistories), new GetChildren< SalesPersonQuotaHistory>(this.GetChildrenSalesPersonQuotaHistories));
             this.salesTerritoryHistories = new EntityCollection< SalesTerritoryHistory>(this, new Associate< SalesTerritoryHistory>(this.AssociateSalesTerritoryHistories), new DeAssociate< SalesTerritoryHistory>(this.DeAssociateSalesTerritoryHistories), new GetChildren< SalesTerritoryHistory>(this.GetChildrenSalesTerritoryHistories));
             this.stores = new EntityCollection< Store>(this, new Associate< Store>(this.AssociateStores), new DeAssociate< Store>(this.DeAssociateStores), new GetChildren< Store>(this.GetChildrenStores));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesPerson entity = obj as SalesPerson;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.BusinessEntityID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.territoryid = DbConvert.ToNullable< int >(reader[COL_TERRITORYID]);
			this.salesquotum = DbConvert.ToNullable< decimal >(reader[COL_SALESQUOTA]);
			this.bonu = (decimal)reader[COL_BONUS];
			this.commissionpct = (decimal)reader[COL_COMMISSIONPCT];
			this.salesytd = (decimal)reader[COL_SALESYTD];
			this.saleslastyear = (decimal)reader[COL_SALESLASTYEAR];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESPERSON))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesQuota), PARAM_SALESQUOTA));
				command.Parameters.Add(dataContext.CreateParameter(this.Bonus, PARAM_BONUS));
				command.Parameters.Add(dataContext.CreateParameter(this.CommissionPct, PARAM_COMMISSIONPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESPERSON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesQuota), PARAM_SALESQUOTA));
				command.Parameters.Add(dataContext.CreateParameter(this.Bonus, PARAM_BONUS));
				command.Parameters.Add(dataContext.CreateParameter(this.CommissionPct, PARAM_COMMISSIONPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESPERSON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.SalesPersonEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.SalesPersonEntity == this)
             salesOrderHeader.SalesPersonEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaders()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.SalesPersonEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesPersonQuotaHistories(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
           salesPersonQuotaHistory.SalesPersonEntity = this;
        }
        
        private void DeAssociateSalesPersonQuotaHistories(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
          if(salesPersonQuotaHistory.SalesPersonEntity == this)
             salesPersonQuotaHistory.SalesPersonEntity = null;
        }
        
        private SalesPersonQuotaHistory[] GetChildrenSalesPersonQuotaHistories()
        {
            SalesPersonQuotaHistory childrenQuery = new SalesPersonQuotaHistory();
            childrenQuery.SalesPersonEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesTerritoryHistories(SalesTerritoryHistory salesTerritoryHistory)
        {
           salesTerritoryHistory.SalesPersonEntity = this;
        }
        
        private void DeAssociateSalesTerritoryHistories(SalesTerritoryHistory salesTerritoryHistory)
        {
          if(salesTerritoryHistory.SalesPersonEntity == this)
             salesTerritoryHistory.SalesPersonEntity = null;
        }
        
        private SalesTerritoryHistory[] GetChildrenSalesTerritoryHistories()
        {
            SalesTerritoryHistory childrenQuery = new SalesTerritoryHistory();
            childrenQuery.SalesPersonEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateStores(Store store)
        {
           store.SalesPersonEntity = this;
        }
        
        private void DeAssociateStores(Store store)
        {
          if(store.SalesPersonEntity == this)
             store.SalesPersonEntity = null;
        }
        
        private Store[] GetChildrenStores()
        {
            Store childrenQuery = new Store();
            childrenQuery.SalesPersonEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
