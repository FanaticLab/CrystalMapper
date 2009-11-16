/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Culture
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
		
		private const string SQL_INSERT_CULTURE = "INSERT INTO Production.Culture([CultureID],[Name],[ModifiedDate]) VALUES (@CultureID,@Name,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_CULTURE = "UPDATE Production.Culture SET  [Name] = @Name, [ModifiedDate] = @ModifiedDate WHERE [CultureID] = @CultureID";
		
		private const string SQL_DELETE_CULTURE = "DELETE FROM Production.Culture WHERE  [CultureID] = @CultureID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected string cultureid = default(string);
	
		protected string name = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< ProductModelProductDescriptionCulture> productModelProductDescriptionCultures ;
        
        #endregion

 		#region Properties	

        [Column( COL_CULTUREID, PARAM_CULTUREID )]
                              public virtual string CultureID 
        {
            get { return this.cultureid; }
			set	{ 
                  if(this.cultureid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CultureID"));  
                        this.cultureid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CultureID"));
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
		
        public EntityCollection< ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures 
        {
            get { return this.productModelProductDescriptionCultures;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Culture()
        {
             this.productModelProductDescriptionCultures = new EntityCollection< ProductModelProductDescriptionCulture>(this, new Associate< ProductModelProductDescriptionCulture>(this.AssociateProductModelProductDescriptionCultures), new DeAssociate< ProductModelProductDescriptionCulture>(this.DeAssociateProductModelProductDescriptionCultures), new GetChildren< ProductModelProductDescriptionCulture>(this.GetChildrenProductModelProductDescriptionCultures));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.cultureid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Culture entity = obj as Culture;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CultureID == entity.CultureID
                        && this.CultureID != default(string)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.cultureid = (string)reader[COL_CULTUREID];
			this.name = (string)reader[COL_NAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
        
        #region Entity Relationship Functions
        
        private void AssociateProductModelProductDescriptionCultures(ProductModelProductDescriptionCulture productModelProductDescriptionCulture)
        {
           productModelProductDescriptionCulture.CultureEntity = this;
        }
        
        private void DeAssociateProductModelProductDescriptionCultures(ProductModelProductDescriptionCulture productModelProductDescriptionCulture)
        {
          if(productModelProductDescriptionCulture.CultureEntity == this)
             productModelProductDescriptionCulture.CultureEntity = null;
        }
        
        private ProductModelProductDescriptionCulture[] GetChildrenProductModelProductDescriptionCultures()
        {
            ProductModelProductDescriptionCulture childrenQuery = new ProductModelProductDescriptionCulture();
            childrenQuery.CultureEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
