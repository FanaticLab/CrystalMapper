/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: address
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
    public partial class address : Entity< address>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.Address";	
     
		public const string COL_ADDRESSID = "AddressID";
		public const string COL_ADDRESSLINE1 = "AddressLine1";
		public const string COL_ADDRESSLINE2 = "AddressLine2";
		public const string COL_CITY = "City";
		public const string COL_STATEPROVINCEID = "StateProvinceID";
		public const string COL_POSTALCODE = "PostalCode";
		public const string COL_SPATIALLOCATION = "SpatialLocation";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_ADDRESSID = "@AddressID";	
        public const string PARAM_ADDRESSLINE1 = "@AddressLine1";	
        public const string PARAM_ADDRESSLINE2 = "@AddressLine2";	
        public const string PARAM_CITY = "@City";	
        public const string PARAM_STATEPROVINCEID = "@StateProvinceID";	
        public const string PARAM_POSTALCODE = "@PostalCode";	
        public const string PARAM_SPATIALLOCATION = "@SpatialLocation";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ADDRESS = "INSERT INTO Person.Address([AddressLine1],[AddressLine2],[City],[StateProvinceID],[PostalCode],[SpatialLocation],[rowguid],[ModifiedDate]) VALUES (@AddressLine1,@AddressLine2,@City,@StateProvinceID,@PostalCode,@SpatialLocation,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_ADDRESS = "UPDATE Person.Address SET  [AddressLine1] = @AddressLine1, [AddressLine2] = @AddressLine2, [City] = @City, [StateProvinceID] = @StateProvinceID, [PostalCode] = @PostalCode, [SpatialLocation] = @SpatialLocation, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [AddressID] = @AddressID";
		
		private const string SQL_DELETE_ADDRESS = "DELETE FROM Person.Address WHERE  [AddressID] = @AddressID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int addressid = default(int);
	
		protected string addressline1 = default(string);
	
		protected string addressline2 = default(string);
	
		protected string city = default(string);
	
		protected int stateprovinceid = default(int);
	
		protected string postalcode = default(string);
	
		protected object spatiallocation = default(object);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected StateProvince stateProvinceEntity;
	
        protected EntityCollection< BusinessEntityAddress> businessEntityAddresses ;
        
        protected EntityCollection< SalesOrderHeader> salesOrderHeaderBillToAddresses ;
        
        protected EntityCollection< SalesOrderHeader> salesOrderHeaderShipToAddresses ;
        
        #endregion

 		#region Properties	

        [Column( COL_ADDRESSID, PARAM_ADDRESSID, default(int))]
                              public virtual int AddressID 
        {
            get { return this.addressid; }
			set	{ 
                  if(this.addressid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AddressID"));  
                        this.addressid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AddressID"));
                    }   
                }
        }	
		
        [Column( COL_ADDRESSLINE1, PARAM_ADDRESSLINE1 )]
                              public virtual string AddressLine1 
        {
            get { return this.addressline1; }
			set	{ 
                  if(this.addressline1 != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AddressLine1"));  
                        this.addressline1 = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AddressLine1"));
                    }   
                }
        }	
		
        [Column( COL_ADDRESSLINE2, PARAM_ADDRESSLINE2 )]
                              public virtual string AddressLine2 
        {
            get { return this.addressline2; }
			set	{ 
                  if(this.addressline2 != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AddressLine2"));  
                        this.addressline2 = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AddressLine2"));
                    }   
                }
        }	
		
        [Column( COL_CITY, PARAM_CITY )]
                              public virtual string City 
        {
            get { return this.city; }
			set	{ 
                  if(this.city != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("City"));  
                        this.city = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("City"));
                    }   
                }
        }	
		
        [Column( COL_POSTALCODE, PARAM_POSTALCODE )]
                              public virtual string PostalCode 
        {
            get { return this.postalcode; }
			set	{ 
                  if(this.postalcode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PostalCode"));  
                        this.postalcode = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PostalCode"));
                    }   
                }
        }	
		
        [Column( COL_SPATIALLOCATION, PARAM_SPATIALLOCATION )]
                              public virtual object SpatialLocation 
        {
            get { return this.spatiallocation; }
			set	{ 
                  if(this.spatiallocation != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SpatialLocation"));  
                        this.spatiallocation = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SpatialLocation"));
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
		
        [Column( COL_STATEPROVINCEID, PARAM_STATEPROVINCEID, default(int))]
                              public virtual int StateProvinceID                
        {
            get
            {
                if(this.stateProvinceEntity == null)
                    return this.stateprovinceid ;
                
                return this.stateProvinceEntity.StateProvinceID;            
            }
            set
            {
                if(this.stateprovinceid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("StateProvinceID"));                    
                    this.stateprovinceid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("StateProvinceID"));
                    
                    this.stateProvinceEntity = null;
                }                
            }          
        }	
        
        public StateProvince StateProvinceEntity
        {
            get { 
                    if(this.stateProvinceEntity == null
                       && this.stateprovinceid != default(int)) 
                    {
                        StateProvince stateProvinceQuery = new StateProvince {
                                                        StateProvinceID = this.stateprovinceid  
                                                        };
                        
                        StateProvince[]  stateProvinces = stateProvinceQuery.ToList();                        
                        if(stateProvinces.Length == 1)
                            this.stateProvinceEntity = stateProvinces[0];                        
                    }
                    
                    return this.stateProvinceEntity; 
                }
			set	{ 
                  if(this.stateProvinceEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StateProvinceEntity"));
                        if (this.stateProvinceEntity != null)
                            this.Parents.Remove(this.stateProvinceEntity);                            
                        
                        if((this.stateProvinceEntity = value) != null) 
                            this.Parents.Add(this.stateProvinceEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StateProvinceEntity"));
                        
                        this.stateprovinceid = this.StateProvinceEntity.StateProvinceID;
                    }   
                }
        }	
		
        public EntityCollection< BusinessEntityAddress> BusinessEntityAddresses 
        {
            get { return this.businessEntityAddresses;}
        }
        
        public EntityCollection< SalesOrderHeader> SalesOrderHeaderBillToAddresses 
        {
            get { return this.salesOrderHeaderBillToAddresses;}
        }
        
        public EntityCollection< SalesOrderHeader> SalesOrderHeaderShipToAddresses 
        {
            get { return this.salesOrderHeaderShipToAddresses;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public address()
        {
             this.businessEntityAddresses = new EntityCollection< BusinessEntityAddress>(this, new Associate< BusinessEntityAddress>(this.AssociateBusinessEntityAddresses), new DeAssociate< BusinessEntityAddress>(this.DeAssociateBusinessEntityAddresses), new GetChildren< BusinessEntityAddress>(this.GetChildrenBusinessEntityAddresses));
             this.salesOrderHeaderBillToAddresses = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaderBillToAddresses), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaderBillToAddresses), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaderBillToAddresses));
             this.salesOrderHeaderShipToAddresses = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaderShipToAddresses), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaderShipToAddresses), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaderShipToAddresses));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.addressid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            address entity = obj as address;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.AddressID == entity.AddressID
                        && this.AddressID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.addressid = (int)reader[COL_ADDRESSID];
			this.addressline1 = (string)reader[COL_ADDRESSLINE1];
			this.addressline2 = DbConvert.ToString(reader[COL_ADDRESSLINE2]);
			this.city = (string)reader[COL_CITY];
			this.stateprovinceid = (int)reader[COL_STATEPROVINCEID];
			this.postalcode = (string)reader[COL_POSTALCODE];
			this.spatiallocation = reader[COL_SPATIALLOCATION];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ADDRESS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.AddressLine1, PARAM_ADDRESSLINE1));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AddressLine2), PARAM_ADDRESSLINE2));
				command.Parameters.Add(dataContext.CreateParameter(this.City, PARAM_CITY));
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.PostalCode, PARAM_POSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SpatialLocation), PARAM_SPATIALLOCATION));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.AddressID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressLine1, PARAM_ADDRESSLINE1));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AddressLine2), PARAM_ADDRESSLINE2));
				command.Parameters.Add(dataContext.CreateParameter(this.City, PARAM_CITY));
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.PostalCode, PARAM_POSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SpatialLocation), PARAM_SPATIALLOCATION));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateBusinessEntityAddresses(BusinessEntityAddress businessEntityAddress)
        {
           businessEntityAddress.AddressEntity = this;
        }
        
        private void DeAssociateBusinessEntityAddresses(BusinessEntityAddress businessEntityAddress)
        {
          if(businessEntityAddress.AddressEntity == this)
             businessEntityAddress.AddressEntity = null;
        }
        
        private BusinessEntityAddress[] GetChildrenBusinessEntityAddresses()
        {
            BusinessEntityAddress childrenQuery = new BusinessEntityAddress();
            childrenQuery.AddressEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesOrderHeaderBillToAddresses(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.BillToAddressEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaderBillToAddresses(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.BillToAddressEntity == this)
             salesOrderHeader.BillToAddressEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaderBillToAddresses()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.BillToAddressEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesOrderHeaderShipToAddresses(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.ShipToAddressEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaderShipToAddresses(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.ShipToAddressEntity == this)
             salesOrderHeader.ShipToAddressEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaderShipToAddresses()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.ShipToAddressEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
