/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductDocument
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
    public partial class ProductDocument : Entity< ProductDocument>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductDocument";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_DOCUMENTNODE = "DocumentNode";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_DOCUMENTNODE = "@DocumentNode";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTDOCUMENT = "INSERT INTO Production.ProductDocument([ProductID],[DocumentNode],[ModifiedDate]) VALUES (@ProductID,@DocumentNode,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_PRODUCTDOCUMENT = "UPDATE Production.ProductDocument SET  [ModifiedDate] = @ModifiedDate WHERE [ProductID] = @ProductID AND [DocumentNode] = @DocumentNode";
		
		private const string SQL_DELETE_PRODUCTDOCUMENT = "DELETE FROM Production.ProductDocument WHERE  [ProductID] = @ProductID AND [DocumentNode] = @DocumentNode ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productid = default(int);
	
		protected object documentnode = default(object);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Document documentEntity;
	
		protected Product productEntity;
	
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
		
        [Column( COL_DOCUMENTNODE, PARAM_DOCUMENTNODE )]
                              public virtual object DocumentNode                
        {
            get
            {
                if(this.documentEntity == null)
                    return this.documentnode ;
                
                return this.documentEntity.DocumentNode;            
            }
            set
            {
                if(this.documentnode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("DocumentNode"));                    
                    this.documentnode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("DocumentNode"));
                    
                    this.documentEntity = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID                
        {
            get
            {
                if(this.productEntity == null)
                    return this.productid ;
                
                return this.productEntity.ProductID;            
            }
            set
            {
                if(this.productid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));                    
                    this.productid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    
                    this.productEntity = null;
                }                
            }          
        }	
        
        public Document DocumentEntity
        {
            get { 
                    if(this.documentEntity == null
                       && this.documentnode != default(object)) 
                    {
                        Document documentQuery = new Document {
                                                        DocumentNode = this.documentnode  
                                                        };
                        
                        Document[]  documents = documentQuery.ToList();                        
                        if(documents.Length == 1)
                            this.documentEntity = documents[0];                        
                    }
                    
                    return this.documentEntity; 
                }
			set	{ 
                  if(this.documentEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DocumentEntity"));
                        if (this.documentEntity != null)
                            this.Parents.Remove(this.documentEntity);                            
                        
                        if((this.documentEntity = value) != null) 
                            this.Parents.Add(this.documentEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DocumentEntity"));
                        
                        this.documentnode = this.DocumentEntity.DocumentNode;
                    }   
                }
        }	
		
        public Product ProductEntity
        {
            get { 
                    if(this.productEntity == null
                       && this.productid != default(int)) 
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.productid  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.productEntity = products[0];                        
                    }
                    
                    return this.productEntity; 
                }
			set	{ 
                  if(this.productEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductEntity"));
                        if (this.productEntity != null)
                            this.Parents.Remove(this.productEntity);                            
                        
                        if((this.productEntity = value) != null) 
                            this.Parents.Add(this.productEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductEntity"));
                        
                        this.productid = this.ProductEntity.ProductID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public ProductDocument()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productid.GetHashCode();
                result = (11 * result) + this.documentnode.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductDocument entity = obj as ProductDocument;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductID == entity.ProductID
                        && this.DocumentNode == entity.DocumentNode
                        && this.ProductID != default(int)
                        && this.DocumentNode != default(object)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productid = (int)reader[COL_PRODUCTID];
			this.documentnode = reader[COL_DOCUMENTNODE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTDOCUMENT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentNode, PARAM_DOCUMENTNODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTDOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentNode, PARAM_DOCUMENTNODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTDOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentNode, PARAM_DOCUMENTNODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
