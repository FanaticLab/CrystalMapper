/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Location
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
    public partial class Location : Entity< Location>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Location";	
     
		public const string COL_LOCATIONID = "LocationID";
		public const string COL_NAME = "Name";
		public const string COL_COSTRATE = "CostRate";
		public const string COL_AVAILABILITY = "Availability";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_LOCATIONID = "@LocationID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_COSTRATE = "@CostRate";	
        public const string PARAM_AVAILABILITY = "@Availability";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_LOCATION = "INSERT INTO Production.Location([Name],[CostRate],[Availability],[ModifiedDate]) VALUES (@Name,@CostRate,@Availability,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_LOCATION = "UPDATE Production.Location SET  [Name] = @Name, [CostRate] = @CostRate, [Availability] = @Availability, [ModifiedDate] = @ModifiedDate WHERE [LocationID] = @LocationID";
		
		private const string SQL_DELETE_LOCATION = "DELETE FROM Production.Location WHERE  [LocationID] = @LocationID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected short locationid = default(short);
	
		protected string name = default(string);
	
		protected decimal costrate = default(decimal);
	
		protected decimal availability = default(decimal);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< ProductInventory> productInventories ;
        
        protected EntityCollection< WorkOrderRouting> workOrderRoutings ;
        
        #endregion

 		#region Properties	

        [Column( COL_LOCATIONID, PARAM_LOCATIONID, default(short))]
                              public virtual short LocationID 
        {
            get { return this.locationid; }
			set	{ 
                  if(this.locationid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LocationID"));  
                        this.locationid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LocationID"));
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
		
        [Column( COL_COSTRATE, PARAM_COSTRATE, typeof(decimal))]
                              public virtual decimal CostRate 
        {
            get { return this.costrate; }
			set	{ 
                  if(this.costrate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CostRate"));  
                        this.costrate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CostRate"));
                    }   
                }
        }	
		
        [Column( COL_AVAILABILITY, PARAM_AVAILABILITY, typeof(decimal))]
                              public virtual decimal Availability 
        {
            get { return this.availability; }
			set	{ 
                  if(this.availability != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Availability"));  
                        this.availability = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Availability"));
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
		
        public EntityCollection< ProductInventory> ProductInventories 
        {
            get { return this.productInventories;}
        }
        
        public EntityCollection< WorkOrderRouting> WorkOrderRoutings 
        {
            get { return this.workOrderRoutings;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Location()
        {
             this.productInventories = new EntityCollection< ProductInventory>(this, new Associate< ProductInventory>(this.AssociateProductInventories), new DeAssociate< ProductInventory>(this.DeAssociateProductInventories), new GetChildren< ProductInventory>(this.GetChildrenProductInventories));
             this.workOrderRoutings = new EntityCollection< WorkOrderRouting>(this, new Associate< WorkOrderRouting>(this.AssociateWorkOrderRoutings), new DeAssociate< WorkOrderRouting>(this.DeAssociateWorkOrderRoutings), new GetChildren< WorkOrderRouting>(this.GetChildrenWorkOrderRoutings));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.locationid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Location entity = obj as Location;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.LocationID == entity.LocationID
                        && this.LocationID != default(short)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.locationid = (short)reader[COL_LOCATIONID];
			this.name = (string)reader[COL_NAME];
			this.costrate = (decimal)reader[COL_COSTRATE];
			this.availability = (decimal)reader[COL_AVAILABILITY];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_LOCATION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CostRate, PARAM_COSTRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Availability, PARAM_AVAILABILITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.LocationID = Convert.ToInt16(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_LOCATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CostRate, PARAM_COSTRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Availability, PARAM_AVAILABILITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_LOCATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProductInventories(ProductInventory productInventory)
        {
           productInventory.LocationEntity = this;
        }
        
        private void DeAssociateProductInventories(ProductInventory productInventory)
        {
          if(productInventory.LocationEntity == this)
             productInventory.LocationEntity = null;
        }
        
        private ProductInventory[] GetChildrenProductInventories()
        {
            ProductInventory childrenQuery = new ProductInventory();
            childrenQuery.LocationEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateWorkOrderRoutings(WorkOrderRouting workOrderRouting)
        {
           workOrderRouting.LocationEntity = this;
        }
        
        private void DeAssociateWorkOrderRoutings(WorkOrderRouting workOrderRouting)
        {
          if(workOrderRouting.LocationEntity == this)
             workOrderRouting.LocationEntity = null;
        }
        
        private WorkOrderRouting[] GetChildrenWorkOrderRoutings()
        {
            WorkOrderRouting childrenQuery = new WorkOrderRouting();
            childrenQuery.LocationEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
