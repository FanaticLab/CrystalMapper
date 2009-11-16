/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductModelIllustration
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
    public partial class ProductModelIllustration : Entity< ProductModelIllustration>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductModelIllustration";	
     
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_ILLUSTRATIONID = "IllustrationID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_ILLUSTRATIONID = "@IllustrationID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTMODELILLUSTRATION = "INSERT INTO Production.ProductModelIllustration([ProductModelID],[IllustrationID],[ModifiedDate]) VALUES (@ProductModelID,@IllustrationID,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_PRODUCTMODELILLUSTRATION = "UPDATE Production.ProductModelIllustration SET  [ModifiedDate] = @ModifiedDate WHERE [ProductModelID] = @ProductModelID AND [IllustrationID] = @IllustrationID";
		
		private const string SQL_DELETE_PRODUCTMODELILLUSTRATION = "DELETE FROM Production.ProductModelIllustration WHERE  [ProductModelID] = @ProductModelID AND [IllustrationID] = @IllustrationID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productmodelid = default(int);
	
		protected int illustrationid = default(int);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Illustration illustrationEntity;
	
		protected ProductModel productModelEntity;
	
        #endregion

 		#region Properties	

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
		
        [Column( COL_ILLUSTRATIONID, PARAM_ILLUSTRATIONID, default(int))]
                              public virtual int IllustrationID                
        {
            get
            {
                if(this.illustrationEntity == null)
                    return this.illustrationid ;
                
                return this.illustrationEntity.IllustrationID;            
            }
            set
            {
                if(this.illustrationid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("IllustrationID"));                    
                    this.illustrationid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("IllustrationID"));
                    
                    this.illustrationEntity = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID, default(int))]
                              public virtual int ProductModelID                
        {
            get
            {
                if(this.productModelEntity == null)
                    return this.productmodelid ;
                
                return this.productModelEntity.ProductModelID;            
            }
            set
            {
                if(this.productmodelid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductModelID"));                    
                    this.productmodelid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductModelID"));
                    
                    this.productModelEntity = null;
                }                
            }          
        }	
        
        public Illustration IllustrationEntity
        {
            get { 
                    if(this.illustrationEntity == null
                       && this.illustrationid != default(int)) 
                    {
                        Illustration illustrationQuery = new Illustration {
                                                        IllustrationID = this.illustrationid  
                                                        };
                        
                        Illustration[]  illustrations = illustrationQuery.ToList();                        
                        if(illustrations.Length == 1)
                            this.illustrationEntity = illustrations[0];                        
                    }
                    
                    return this.illustrationEntity; 
                }
			set	{ 
                  if(this.illustrationEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("IllustrationEntity"));
                        if (this.illustrationEntity != null)
                            this.Parents.Remove(this.illustrationEntity);                            
                        
                        if((this.illustrationEntity = value) != null) 
                            this.Parents.Add(this.illustrationEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("IllustrationEntity"));
                        
                        this.illustrationid = this.IllustrationEntity.IllustrationID;
                    }   
                }
        }	
		
        public ProductModel ProductModelEntity
        {
            get { 
                    if(this.productModelEntity == null
                       && this.productmodelid != default(int)) 
                    {
                        ProductModel productModelQuery = new ProductModel {
                                                        ProductModelID = this.productmodelid  
                                                        };
                        
                        ProductModel[]  productModels = productModelQuery.ToList();                        
                        if(productModels.Length == 1)
                            this.productModelEntity = productModels[0];                        
                    }
                    
                    return this.productModelEntity; 
                }
			set	{ 
                  if(this.productModelEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductModelEntity"));
                        if (this.productModelEntity != null)
                            this.Parents.Remove(this.productModelEntity);                            
                        
                        if((this.productModelEntity = value) != null) 
                            this.Parents.Add(this.productModelEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductModelEntity"));
                        
                        this.productmodelid = this.ProductModelEntity.ProductModelID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public ProductModelIllustration()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productmodelid.GetHashCode();
                result = (11 * result) + this.illustrationid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductModelIllustration entity = obj as ProductModelIllustration;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductModelID == entity.ProductModelID
                        && this.IllustrationID == entity.IllustrationID
                        && this.ProductModelID != default(int)
                        && this.IllustrationID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productmodelid = (int)reader[COL_PRODUCTMODELID];
			this.illustrationid = (int)reader[COL_ILLUSTRATIONID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTMODELILLUSTRATION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTMODELILLUSTRATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTMODELILLUSTRATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));				
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
