/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: UnitMeasure
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
    public partial class UnitMeasure : Entity< UnitMeasure>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.UnitMeasure";	
     
		public const string COL_UNITMEASURECODE = "UnitMeasureCode";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_UNITMEASURECODE = "@UnitMeasureCode";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_UNITMEASURE = "INSERT INTO Production.UnitMeasure([UnitMeasureCode],[Name],[ModifiedDate]) VALUES (@UnitMeasureCode,@Name,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_UNITMEASURE = "UPDATE Production.UnitMeasure SET  [Name] = @Name, [ModifiedDate] = @ModifiedDate WHERE [UnitMeasureCode] = @UnitMeasureCode";
		
		private const string SQL_DELETE_UNITMEASURE = "DELETE FROM Production.UnitMeasure WHERE  [UnitMeasureCode] = @UnitMeasureCode ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected string unitmeasurecode = default(string);
	
		protected string name = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< BillOfMaterial> billOfMaterials ;
        
        protected EntityCollection< Product> productSizeUnitMeasureCodes ;
        
        protected EntityCollection< Product> productWeightUnitMeasureCodes ;
        
        protected EntityCollection< ProductVendor> productVendors ;
        
        #endregion

 		#region Properties	

        [Column( COL_UNITMEASURECODE, PARAM_UNITMEASURECODE )]
                              public virtual string UnitMeasureCode 
        {
            get { return this.unitmeasurecode; }
			set	{ 
                  if(this.unitmeasurecode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitMeasureCode"));  
                        this.unitmeasurecode = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitMeasureCode"));
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
		
        public EntityCollection< BillOfMaterial> BillOfMaterials 
        {
            get { return this.billOfMaterials;}
        }
        
        public EntityCollection< Product> ProductSizeUnitMeasureCodes 
        {
            get { return this.productSizeUnitMeasureCodes;}
        }
        
        public EntityCollection< Product> ProductWeightUnitMeasureCodes 
        {
            get { return this.productWeightUnitMeasureCodes;}
        }
        
        public EntityCollection< ProductVendor> ProductVendors 
        {
            get { return this.productVendors;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public UnitMeasure()
        {
             this.billOfMaterials = new EntityCollection< BillOfMaterial>(this, new Associate< BillOfMaterial>(this.AssociateBillOfMaterials), new DeAssociate< BillOfMaterial>(this.DeAssociateBillOfMaterials), new GetChildren< BillOfMaterial>(this.GetChildrenBillOfMaterials));
             this.productSizeUnitMeasureCodes = new EntityCollection< Product>(this, new Associate< Product>(this.AssociateProductSizeUnitMeasureCodes), new DeAssociate< Product>(this.DeAssociateProductSizeUnitMeasureCodes), new GetChildren< Product>(this.GetChildrenProductSizeUnitMeasureCodes));
             this.productWeightUnitMeasureCodes = new EntityCollection< Product>(this, new Associate< Product>(this.AssociateProductWeightUnitMeasureCodes), new DeAssociate< Product>(this.DeAssociateProductWeightUnitMeasureCodes), new GetChildren< Product>(this.GetChildrenProductWeightUnitMeasureCodes));
             this.productVendors = new EntityCollection< ProductVendor>(this, new Associate< ProductVendor>(this.AssociateProductVendors), new DeAssociate< ProductVendor>(this.DeAssociateProductVendors), new GetChildren< ProductVendor>(this.GetChildrenProductVendors));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.unitmeasurecode.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            UnitMeasure entity = obj as UnitMeasure;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.UnitMeasureCode == entity.UnitMeasureCode
                        && this.UnitMeasureCode != default(string)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.unitmeasurecode = (string)reader[COL_UNITMEASURECODE];
			this.name = (string)reader[COL_NAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_UNITMEASURE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_UNITMEASURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_UNITMEASURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateBillOfMaterials(BillOfMaterial billOfMaterial)
        {
           billOfMaterial.UnitMeasureEntity = this;
        }
        
        private void DeAssociateBillOfMaterials(BillOfMaterial billOfMaterial)
        {
          if(billOfMaterial.UnitMeasureEntity == this)
             billOfMaterial.UnitMeasureEntity = null;
        }
        
        private BillOfMaterial[] GetChildrenBillOfMaterials()
        {
            BillOfMaterial childrenQuery = new BillOfMaterial();
            childrenQuery.UnitMeasureEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductSizeUnitMeasureCodes(Product product)
        {
           product.SizeUnitMeasureEntity = this;
        }
        
        private void DeAssociateProductSizeUnitMeasureCodes(Product product)
        {
          if(product.SizeUnitMeasureEntity == this)
             product.SizeUnitMeasureEntity = null;
        }
        
        private Product[] GetChildrenProductSizeUnitMeasureCodes()
        {
            Product childrenQuery = new Product();
            childrenQuery.SizeUnitMeasureEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductWeightUnitMeasureCodes(Product product)
        {
           product.WeightUnitMeasureEntity = this;
        }
        
        private void DeAssociateProductWeightUnitMeasureCodes(Product product)
        {
          if(product.WeightUnitMeasureEntity == this)
             product.WeightUnitMeasureEntity = null;
        }
        
        private Product[] GetChildrenProductWeightUnitMeasureCodes()
        {
            Product childrenQuery = new Product();
            childrenQuery.WeightUnitMeasureEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductVendors(ProductVendor productVendor)
        {
           productVendor.UnitMeasureEntity = this;
        }
        
        private void DeAssociateProductVendors(ProductVendor productVendor)
        {
          if(productVendor.UnitMeasureEntity == this)
             productVendor.UnitMeasureEntity = null;
        }
        
        private ProductVendor[] GetChildrenProductVendors()
        {
            ProductVendor childrenQuery = new ProductVendor();
            childrenQuery.UnitMeasureEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
