/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ScrapReason
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
    public partial class ScrapReason : Entity< ScrapReason>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ScrapReason";	
     
		public const string COL_SCRAPREASONID = "ScrapReasonID";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SCRAPREASONID = "@ScrapReasonID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SCRAPREASON = "INSERT INTO Production.ScrapReason([Name],[ModifiedDate]) VALUES (@Name,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SCRAPREASON = "UPDATE Production.ScrapReason SET  [Name] = @Name, [ModifiedDate] = @ModifiedDate WHERE [ScrapReasonID] = @ScrapReasonID";
		
		private const string SQL_DELETE_SCRAPREASON = "DELETE FROM Production.ScrapReason WHERE  [ScrapReasonID] = @ScrapReasonID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected short scrapreasonid = default(short);
	
		protected string name = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< WorkOrder> workOrders ;
        
        #endregion

 		#region Properties	

        [Column( COL_SCRAPREASONID, PARAM_SCRAPREASONID, default(short))]
                              public virtual short ScrapReasonID 
        {
            get { return this.scrapreasonid; }
			set	{ 
                  if(this.scrapreasonid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ScrapReasonID"));  
                        this.scrapreasonid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ScrapReasonID"));
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
		
        public EntityCollection< WorkOrder> WorkOrders 
        {
            get { return this.workOrders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ScrapReason()
        {
             this.workOrders = new EntityCollection< WorkOrder>(this, new Associate< WorkOrder>(this.AssociateWorkOrders), new DeAssociate< WorkOrder>(this.DeAssociateWorkOrders), new GetChildren< WorkOrder>(this.GetChildrenWorkOrders));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.scrapreasonid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ScrapReason entity = obj as ScrapReason;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ScrapReasonID == entity.ScrapReasonID
                        && this.ScrapReasonID != default(short)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.scrapreasonid = (short)reader[COL_SCRAPREASONID];
			this.name = (string)reader[COL_NAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SCRAPREASON))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ScrapReasonID = Convert.ToInt16(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SCRAPREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ScrapReasonID, PARAM_SCRAPREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SCRAPREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ScrapReasonID, PARAM_SCRAPREASONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateWorkOrders(WorkOrder workOrder)
        {
           workOrder.ScrapReasonEntity = this;
        }
        
        private void DeAssociateWorkOrders(WorkOrder workOrder)
        {
          if(workOrder.ScrapReasonEntity == this)
             workOrder.ScrapReasonEntity = null;
        }
        
        private WorkOrder[] GetChildrenWorkOrders()
        {
            WorkOrder childrenQuery = new WorkOrder();
            childrenQuery.ScrapReasonEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
