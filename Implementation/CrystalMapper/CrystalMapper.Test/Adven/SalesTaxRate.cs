/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesTaxRate
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
    public partial class SalesTaxRate : Entity< SalesTaxRate>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesTaxRate";	
     
		public const string COL_SALESTAXRATEID = "SalesTaxRateID";
		public const string COL_STATEPROVINCEID = "StateProvinceID";
		public const string COL_TAXTYPE = "TaxType";
		public const string COL_TAXRATE = "TaxRate";
		public const string COL_NAME = "Name";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESTAXRATEID = "@SalesTaxRateID";	
        public const string PARAM_STATEPROVINCEID = "@StateProvinceID";	
        public const string PARAM_TAXTYPE = "@TaxType";	
        public const string PARAM_TAXRATE = "@TaxRate";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESTAXRATE = "INSERT INTO Sales.SalesTaxRate([StateProvinceID],[TaxType],[TaxRate],[Name],[rowguid],[ModifiedDate]) VALUES (@StateProvinceID,@TaxType,@TaxRate,@Name,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SALESTAXRATE = "UPDATE Sales.SalesTaxRate SET  [StateProvinceID] = @StateProvinceID, [TaxType] = @TaxType, [TaxRate] = @TaxRate, [Name] = @Name, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [SalesTaxRateID] = @SalesTaxRateID";
		
		private const string SQL_DELETE_SALESTAXRATE = "DELETE FROM Sales.SalesTaxRate WHERE  [SalesTaxRateID] = @SalesTaxRateID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int salestaxrateid = default(int);
	
		protected int stateprovinceid = default(int);
	
		protected byte taxtype = default(byte);
	
		protected decimal taxrate = default(decimal);
	
		protected string name = default(string);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected StateProvince stateProvinceEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_SALESTAXRATEID, PARAM_SALESTAXRATEID, default(int))]
                              public virtual int SalesTaxRateID 
        {
            get { return this.salestaxrateid; }
			set	{ 
                  if(this.salestaxrateid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesTaxRateID"));  
                        this.salestaxrateid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesTaxRateID"));
                    }   
                }
        }	
		
        [Column( COL_TAXTYPE, PARAM_TAXTYPE, default(byte))]
                              public virtual byte TaxType 
        {
            get { return this.taxtype; }
			set	{ 
                  if(this.taxtype != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TaxType"));  
                        this.taxtype = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TaxType"));
                    }   
                }
        }	
		
        [Column( COL_TAXRATE, PARAM_TAXRATE, typeof(decimal))]
                              public virtual decimal TaxRate 
        {
            get { return this.taxrate; }
			set	{ 
                  if(this.taxrate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TaxRate"));  
                        this.taxrate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TaxRate"));
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
		
        
        #endregion        
        
        #region Methods     
		
        public SalesTaxRate()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.salestaxrateid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesTaxRate entity = obj as SalesTaxRate;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SalesTaxRateID == entity.SalesTaxRateID
                        && this.SalesTaxRateID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.salestaxrateid = (int)reader[COL_SALESTAXRATEID];
			this.stateprovinceid = (int)reader[COL_STATEPROVINCEID];
			this.taxtype = (byte)reader[COL_TAXTYPE];
			this.taxrate = (decimal)reader[COL_TAXRATE];
			this.name = (string)reader[COL_NAME];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESTAXRATE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxType, PARAM_TAXTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxRate, PARAM_TAXRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.SalesTaxRateID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESTAXRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesTaxRateID, PARAM_SALESTAXRATEID));
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxType, PARAM_TAXTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxRate, PARAM_TAXRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESTAXRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesTaxRateID, PARAM_SALESTAXRATEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
