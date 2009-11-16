/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductModelProductDescriptionCulture
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
    public partial class ProductModelProductDescriptionCulture : Entity< ProductModelProductDescriptionCulture>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductModelProductDescriptionCulture";	
     
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_PRODUCTDESCRIPTIONID = "ProductDescriptionID";
		public const string COL_CULTUREID = "CultureID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_PRODUCTDESCRIPTIONID = "@ProductDescriptionID";	
        public const string PARAM_CULTUREID = "@CultureID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE = "INSERT INTO Production.ProductModelProductDescriptionCulture([ProductModelID],[ProductDescriptionID],[CultureID],[ModifiedDate]) VALUES (@ProductModelID,@ProductDescriptionID,@CultureID,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE = "UPDATE Production.ProductModelProductDescriptionCulture SET  [ModifiedDate] = @ModifiedDate WHERE [ProductModelID] = @ProductModelID AND [ProductDescriptionID] = @ProductDescriptionID AND [CultureID] = @CultureID";
		
		private const string SQL_DELETE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE = "DELETE FROM Production.ProductModelProductDescriptionCulture WHERE  [ProductModelID] = @ProductModelID AND [ProductDescriptionID] = @ProductDescriptionID AND [CultureID] = @CultureID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productmodelid = default(int);
	
		protected int productdescriptionid = default(int);
	
		protected string cultureid = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Culture cultureEntity;
	
		protected ProductDescription productDescriptionEntity;
	
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
		
        [Column( COL_CULTUREID, PARAM_CULTUREID )]
                              public virtual string CultureID                
        {
            get
            {
                if(this.cultureEntity == null)
                    return this.cultureid ;
                
                return this.cultureEntity.CultureID;            
            }
            set
            {
                if(this.cultureid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CultureID"));                    
                    this.cultureid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CultureID"));
                    
                    this.cultureEntity = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTDESCRIPTIONID, PARAM_PRODUCTDESCRIPTIONID, default(int))]
                              public virtual int ProductDescriptionID                
        {
            get
            {
                if(this.productDescriptionEntity == null)
                    return this.productdescriptionid ;
                
                return this.productDescriptionEntity.ProductDescriptionID;            
            }
            set
            {
                if(this.productdescriptionid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductDescriptionID"));                    
                    this.productdescriptionid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductDescriptionID"));
                    
                    this.productDescriptionEntity = null;
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
        
        public Culture CultureEntity
        {
            get { 
                    if(this.cultureEntity == null
                       && this.cultureid != default(string)) 
                    {
                        Culture cultureQuery = new Culture {
                                                        CultureID = this.cultureid  
                                                        };
                        
                        Culture[]  cultures = cultureQuery.ToList();                        
                        if(cultures.Length == 1)
                            this.cultureEntity = cultures[0];                        
                    }
                    
                    return this.cultureEntity; 
                }
			set	{ 
                  if(this.cultureEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CultureEntity"));
                        if (this.cultureEntity != null)
                            this.Parents.Remove(this.cultureEntity);                            
                        
                        if((this.cultureEntity = value) != null) 
                            this.Parents.Add(this.cultureEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CultureEntity"));
                        
                        this.cultureid = this.CultureEntity.CultureID;
                    }   
                }
        }	
		
        public ProductDescription ProductDescriptionEntity
        {
            get { 
                    if(this.productDescriptionEntity == null
                       && this.productdescriptionid != default(int)) 
                    {
                        ProductDescription productDescriptionQuery = new ProductDescription {
                                                        ProductDescriptionID = this.productdescriptionid  
                                                        };
                        
                        ProductDescription[]  productDescriptions = productDescriptionQuery.ToList();                        
                        if(productDescriptions.Length == 1)
                            this.productDescriptionEntity = productDescriptions[0];                        
                    }
                    
                    return this.productDescriptionEntity; 
                }
			set	{ 
                  if(this.productDescriptionEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductDescriptionEntity"));
                        if (this.productDescriptionEntity != null)
                            this.Parents.Remove(this.productDescriptionEntity);                            
                        
                        if((this.productDescriptionEntity = value) != null) 
                            this.Parents.Add(this.productDescriptionEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductDescriptionEntity"));
                        
                        this.productdescriptionid = this.ProductDescriptionEntity.ProductDescriptionID;
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
		
        public ProductModelProductDescriptionCulture()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productmodelid.GetHashCode();
                result = (11 * result) + this.productdescriptionid.GetHashCode();
                result = (11 * result) + this.cultureid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductModelProductDescriptionCulture entity = obj as ProductModelProductDescriptionCulture;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductModelID == entity.ProductModelID
                        && this.ProductDescriptionID == entity.ProductDescriptionID
                        && this.CultureID == entity.CultureID
                        && this.ProductModelID != default(int)
                        && this.ProductDescriptionID != default(int)
                        && this.CultureID != default(string)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productmodelid = (int)reader[COL_PRODUCTMODELID];
			this.productdescriptionid = (int)reader[COL_PRODUCTDESCRIPTIONID];
			this.cultureid = (string)reader[COL_CULTUREID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));				
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
