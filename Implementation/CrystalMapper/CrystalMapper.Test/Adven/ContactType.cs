/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ContactType
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
    public partial class ContactType : Entity< ContactType>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.ContactType";	
     
		public const string COL_CONTACTTYPEID = "ContactTypeID";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CONTACTTYPEID = "@ContactTypeID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CONTACTTYPE = "INSERT INTO Person.ContactType([Name],[ModifiedDate]) VALUES (@Name,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_CONTACTTYPE = "UPDATE Person.ContactType SET  [Name] = @Name, [ModifiedDate] = @ModifiedDate WHERE [ContactTypeID] = @ContactTypeID";
		
		private const string SQL_DELETE_CONTACTTYPE = "DELETE FROM Person.ContactType WHERE  [ContactTypeID] = @ContactTypeID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int contacttypeid = default(int);
	
		protected string name = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< BusinessEntityContact> businessEntityContacts ;
        
        #endregion

 		#region Properties	

        [Column( COL_CONTACTTYPEID, PARAM_CONTACTTYPEID, default(int))]
                              public virtual int ContactTypeID 
        {
            get { return this.contacttypeid; }
			set	{ 
                  if(this.contacttypeid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ContactTypeID"));  
                        this.contacttypeid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ContactTypeID"));
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
		
        public EntityCollection< BusinessEntityContact> BusinessEntityContacts 
        {
            get { return this.businessEntityContacts;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ContactType()
        {
             this.businessEntityContacts = new EntityCollection< BusinessEntityContact>(this, new Associate< BusinessEntityContact>(this.AssociateBusinessEntityContacts), new DeAssociate< BusinessEntityContact>(this.DeAssociateBusinessEntityContacts), new GetChildren< BusinessEntityContact>(this.GetChildrenBusinessEntityContacts));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.contacttypeid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ContactType entity = obj as ContactType;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ContactTypeID == entity.ContactTypeID
                        && this.ContactTypeID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.contacttypeid = (int)reader[COL_CONTACTTYPEID];
			this.name = (string)reader[COL_NAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CONTACTTYPE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ContactTypeID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CONTACTTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CONTACTTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateBusinessEntityContacts(BusinessEntityContact businessEntityContact)
        {
           businessEntityContact.ContactTypeEntity = this;
        }
        
        private void DeAssociateBusinessEntityContacts(BusinessEntityContact businessEntityContact)
        {
          if(businessEntityContact.ContactTypeEntity == this)
             businessEntityContact.ContactTypeEntity = null;
        }
        
        private BusinessEntityContact[] GetChildrenBusinessEntityContacts()
        {
            BusinessEntityContact childrenQuery = new BusinessEntityContact();
            childrenQuery.ContactTypeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
