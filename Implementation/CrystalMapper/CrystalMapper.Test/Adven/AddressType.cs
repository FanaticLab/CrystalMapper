/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: AddressType
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
    public partial class AddressType : Entity< AddressType>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.AddressType";	
     
		public const string COL_ADDRESSTYPEID = "AddressTypeID";
		public const string COL_NAME = "Name";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_ADDRESSTYPEID = "@AddressTypeID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ADDRESSTYPE = "INSERT INTO Person.AddressType([Name],[rowguid],[ModifiedDate]) VALUES (@Name,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_ADDRESSTYPE = "UPDATE Person.AddressType SET  [Name] = @Name, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [AddressTypeID] = @AddressTypeID";
		
		private const string SQL_DELETE_ADDRESSTYPE = "DELETE FROM Person.AddressType WHERE  [AddressTypeID] = @AddressTypeID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int addresstypeid = default(int);
	
		protected string name = default(string);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< BusinessEntityAddress> businessEntityAddresses ;
        
        #endregion

 		#region Properties	

        [Column( COL_ADDRESSTYPEID, PARAM_ADDRESSTYPEID, default(int))]
                              public virtual int AddressTypeID 
        {
            get { return this.addresstypeid; }
			set	{ 
                  if(this.addresstypeid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AddressTypeID"));  
                        this.addresstypeid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AddressTypeID"));
                    }   
                }
        }	
		
        [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name 
        {
            get { return this.name; }
			set	{ 
                  if(this.name != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Name"));  
                        this.name = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
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
		
        public EntityCollection< BusinessEntityAddress> BusinessEntityAddresses 
        {
            get { return this.businessEntityAddresses;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public AddressType()
        {
             this.businessEntityAddresses = new EntityCollection< BusinessEntityAddress>(this, new Associate< BusinessEntityAddress>(this.AssociateBusinessEntityAddresses), new DeAssociate< BusinessEntityAddress>(this.DeAssociateBusinessEntityAddresses), new GetChildren< BusinessEntityAddress>(this.GetChildrenBusinessEntityAddresses));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.addresstypeid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            AddressType entity = obj as AddressType;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.AddressTypeID == entity.AddressTypeID
                        && this.AddressTypeID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.addresstypeid = (int)reader[COL_ADDRESSTYPEID];
			this.name = (string)reader[COL_NAME];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ADDRESSTYPE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.AddressTypeID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ADDRESSTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ADDRESSTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateBusinessEntityAddresses(BusinessEntityAddress businessEntityAddress)
        {
           businessEntityAddress.AddressTypeEntity = this;
        }
        
        private void DeAssociateBusinessEntityAddresses(BusinessEntityAddress businessEntityAddress)
        {
          if(businessEntityAddress.AddressTypeEntity == this)
             businessEntityAddress.AddressTypeEntity = null;
        }
        
        private BusinessEntityAddress[] GetChildrenBusinessEntityAddresses()
        {
            BusinessEntityAddress childrenQuery = new BusinessEntityAddress();
            childrenQuery.AddressTypeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
