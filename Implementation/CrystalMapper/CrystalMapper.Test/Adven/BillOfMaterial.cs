/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: BillOfMaterial
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
    public partial class BillOfMaterial : Entity< BillOfMaterial>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.BillOfMaterials";	
     
		public const string COL_BILLOFMATERIALSID = "BillOfMaterialsID";
		public const string COL_PRODUCTASSEMBLYID = "ProductAssemblyID";
		public const string COL_COMPONENTID = "ComponentID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_UNITMEASURECODE = "UnitMeasureCode";
		public const string COL_BOMLEVEL = "BOMLevel";
		public const string COL_PERASSEMBLYQTY = "PerAssemblyQty";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BILLOFMATERIALSID = "@BillOfMaterialsID";	
        public const string PARAM_PRODUCTASSEMBLYID = "@ProductAssemblyID";	
        public const string PARAM_COMPONENTID = "@ComponentID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_UNITMEASURECODE = "@UnitMeasureCode";	
        public const string PARAM_BOMLEVEL = "@BOMLevel";	
        public const string PARAM_PERASSEMBLYQTY = "@PerAssemblyQty";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_BILLOFMATERIALS = "INSERT INTO Production.BillOfMaterials([ProductAssemblyID],[ComponentID],[StartDate],[EndDate],[UnitMeasureCode],[BOMLevel],[PerAssemblyQty],[ModifiedDate]) VALUES (@ProductAssemblyID,@ComponentID,@StartDate,@EndDate,@UnitMeasureCode,@BOMLevel,@PerAssemblyQty,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_BILLOFMATERIALS = "UPDATE Production.BillOfMaterials SET  [ProductAssemblyID] = @ProductAssemblyID, [ComponentID] = @ComponentID, [StartDate] = @StartDate, [EndDate] = @EndDate, [UnitMeasureCode] = @UnitMeasureCode, [BOMLevel] = @BOMLevel, [PerAssemblyQty] = @PerAssemblyQty, [ModifiedDate] = @ModifiedDate WHERE [BillOfMaterialsID] = @BillOfMaterialsID";
		
		private const string SQL_DELETE_BILLOFMATERIALS = "DELETE FROM Production.BillOfMaterials WHERE  [BillOfMaterialsID] = @BillOfMaterialsID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int billofmaterialsid = default(int);
	
		protected int? productassemblyid = default(int?);
	
		protected int componentid = default(int);
	
		protected System.DateTime startdate = default(System.DateTime);
	
		protected System.DateTime? enddate = default(System.DateTime?);
	
		protected string unitmeasurecode = default(string);
	
		protected short bomlevel = default(short);
	
		protected decimal perassemblyqty = default(decimal);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product componentEntity;
	
		protected Product productassemblyEntity;
	
		protected UnitMeasure unitMeasureEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_BILLOFMATERIALSID, PARAM_BILLOFMATERIALSID, default(int))]
                              public virtual int BillOfMaterialsID 
        {
            get { return this.billofmaterialsid; }
			set	{ 
                  if(this.billofmaterialsid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("BillOfMaterialsID"));  
                        this.billofmaterialsid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("BillOfMaterialsID"));
                    }   
                }
        }	
		
        [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate 
        {
            get { return this.startdate; }
			set	{ 
                  if(this.startdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StartDate"));  
                        this.startdate = value; 
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
		
        [Column( COL_BOMLEVEL, PARAM_BOMLEVEL, default(short))]
                              public virtual short BOMLevel 
        {
            get { return this.bomlevel; }
			set	{ 
                  if(this.bomlevel != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("BOMLevel"));  
                        this.bomlevel = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("BOMLevel"));
                    }   
                }
        }	
		
        [Column( COL_PERASSEMBLYQTY, PARAM_PERASSEMBLYQTY, typeof(decimal))]
                              public virtual decimal PerAssemblyQty 
        {
            get { return this.perassemblyqty; }
			set	{ 
                  if(this.perassemblyqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PerAssemblyQty"));  
                        this.perassemblyqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PerAssemblyQty"));
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
		
        [Column( COL_COMPONENTID, PARAM_COMPONENTID, default(int))]
                              public virtual int ComponentID                
        {
            get
            {
                if(this.componentEntity == null)
                    return this.componentid ;
                
                return this.componentEntity.ProductID;            
            }
            set
            {
                if(this.componentid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ComponentID"));                    
                    this.componentid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ComponentID"));
                    
                    this.componentEntity = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTASSEMBLYID, PARAM_PRODUCTASSEMBLYID )]
                              public virtual int? ProductAssemblyID                
        {
            get
            {
                if(this.productassemblyEntity == null)
                    return this.productassemblyid ;
                
                return this.productassemblyEntity.ProductID;            
            }
            set
            {
                if(this.productassemblyid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductAssemblyID"));                    
                    this.productassemblyid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductAssemblyID"));
                    
                    this.productassemblyEntity = null;
                }                
            }          
        }	
        
        [Column( COL_UNITMEASURECODE, PARAM_UNITMEASURECODE )]
                              public virtual string UnitMeasureCode                
        {
            get
            {
                if(this.unitMeasureEntity == null)
                    return this.unitmeasurecode ;
                
                return this.unitMeasureEntity.UnitMeasureCode;            
            }
            set
            {
                if(this.unitmeasurecode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("UnitMeasureCode"));                    
                    this.unitmeasurecode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("UnitMeasureCode"));
                    
                    this.unitMeasureEntity = null;
                }                
            }          
        }	
        
        public Product ComponentEntity
        {
            get { 
                    if(this.componentEntity == null
                       && this.componentid != default(int)) 
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.componentid  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.componentEntity = products[0];                        
                    }
                    
                    return this.componentEntity; 
                }
			set	{ 
                  if(this.componentEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ComponentEntity"));
                        if (this.componentEntity != null)
                            this.Parents.Remove(this.componentEntity);                            
                        
                        if((this.componentEntity = value) != null) 
                            this.Parents.Add(this.componentEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ComponentEntity"));
                        
                        this.componentid = this.ComponentEntity.ProductID;
                    }   
                }
        }	
		
        public Product ProductAssemblyEntity
        {
            get { 
                    if(this.productassemblyEntity == null
                       && this.productassemblyid.HasValue )
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.productassemblyid.Value  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.productassemblyEntity = products[0];                        
                    }
                    
                    return this.productassemblyEntity; 
                }
			set	{ 
                  if(this.productassemblyEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductAssemblyEntity"));
                        if (this.productassemblyEntity != null)
                            this.Parents.Remove(this.productassemblyEntity);                            
                        
                        if((this.productassemblyEntity = value) != null) 
                            this.Parents.Add(this.productassemblyEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductAssemblyEntity"));
                        
                        this.productassemblyid = this.ProductAssemblyEntity.ProductID;
                    }   
                }
        }	
		
        public UnitMeasure UnitMeasureEntity
        {
            get { 
                    if(this.unitMeasureEntity == null
                       && this.unitmeasurecode != default(string)) 
                    {
                        UnitMeasure unitMeasureQuery = new UnitMeasure {
                                                        UnitMeasureCode = this.unitmeasurecode  
                                                        };
                        
                        UnitMeasure[]  unitMeasures = unitMeasureQuery.ToList();                        
                        if(unitMeasures.Length == 1)
                            this.unitMeasureEntity = unitMeasures[0];                        
                    }
                    
                    return this.unitMeasureEntity; 
                }
			set	{ 
                  if(this.unitMeasureEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitMeasureEntity"));
                        if (this.unitMeasureEntity != null)
                            this.Parents.Remove(this.unitMeasureEntity);                            
                        
                        if((this.unitMeasureEntity = value) != null) 
                            this.Parents.Add(this.unitMeasureEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitMeasureEntity"));
                        
                        this.unitmeasurecode = this.UnitMeasureEntity.UnitMeasureCode;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public BillOfMaterial()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.billofmaterialsid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            BillOfMaterial entity = obj as BillOfMaterial;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BillOfMaterialsID == entity.BillOfMaterialsID
                        && this.BillOfMaterialsID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.billofmaterialsid = (int)reader[COL_BILLOFMATERIALSID];
			this.productassemblyid = DbConvert.ToNullable< int >(reader[COL_PRODUCTASSEMBLYID]);
			this.componentid = (int)reader[COL_COMPONENTID];
			this.startdate = (System.DateTime)reader[COL_STARTDATE];
			this.enddate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.unitmeasurecode = (string)reader[COL_UNITMEASURECODE];
			this.bomlevel = (short)reader[COL_BOMLEVEL];
			this.perassemblyqty = (decimal)reader[COL_PERASSEMBLYQTY];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_BILLOFMATERIALS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductAssemblyID), PARAM_PRODUCTASSEMBLYID));
				command.Parameters.Add(dataContext.CreateParameter(this.ComponentID, PARAM_COMPONENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.BOMLevel, PARAM_BOMLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.PerAssemblyQty, PARAM_PERASSEMBLYQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.BillOfMaterialsID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_BILLOFMATERIALS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BillOfMaterialsID, PARAM_BILLOFMATERIALSID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductAssemblyID), PARAM_PRODUCTASSEMBLYID));
				command.Parameters.Add(dataContext.CreateParameter(this.ComponentID, PARAM_COMPONENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.BOMLevel, PARAM_BOMLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.PerAssemblyQty, PARAM_PERASSEMBLYQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_BILLOFMATERIALS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BillOfMaterialsID, PARAM_BILLOFMATERIALSID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
