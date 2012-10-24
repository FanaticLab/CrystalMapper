/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:41 PM
 * 
 * Class: Territory
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
using CrystalMapper.Generic;

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Territory : Entity< Territory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Territories";	
     
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_TERRITORYDESCRIPTION = "TerritoryDescription";
		public const string COL_REGIONID = "RegionID";
		
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_TERRITORYDESCRIPTION = "@TerritoryDescription";	
        public const string PARAM_REGIONID = "@RegionID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_TERRITORIES = "INSERT INTO dbo.Territories ( [TerritoryID], [TerritoryDescription], [RegionID]) VALUES ( @TerritoryID, @TerritoryDescription, @RegionID);"  ;
		
		private const string SQL_UPDATE_TERRITORIES = "UPDATE dbo.Territories SET [TerritoryDescription] = @TerritoryDescription, [RegionID] = @RegionID WHERE [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_TERRITORIES = "DELETE FROM dbo.Territories WHERE  [TerritoryID] = @TerritoryID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected string territoryid = default(string);
	
		protected string territorydescription = default(string);
	
		protected int regionid = default(int);
	
		protected Region regionRef;
	
        #endregion

 		#region Properties	

        [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual string TerritoryID 
        {
            get { return this.territoryid; }
			set	{ 
                  if(this.territoryid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryID"));  
                        this.territoryid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryID"));
                    }   
                }
        }	
		
        [Column( COL_TERRITORYDESCRIPTION, PARAM_TERRITORYDESCRIPTION )]
                              public virtual string TerritoryDescription 
        {
            get { return this.territorydescription; }
			set	{ 
                  if(this.territorydescription != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryDescription"));  
                        this.territorydescription = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryDescription"));
                    }   
                }
        }	
		
        [Column( COL_REGIONID, PARAM_REGIONID, default(int))]
                              public virtual int RegionID                
        {
            get
            {
                if(this.regionRef == null)
                    return this.regionid ;
                
                return this.regionRef.RegionID;            
            }
            set
            {
                if(this.regionid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("RegionID"));                    
                    this.regionid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("RegionID"));
                    
                    this.regionRef = null;
                }                
            }          
        }	
        
        public Region RegionRef
        {
            get { 
                    if(this.regionRef == null
                       && this.regionid != default(int)) 
                    {
                        Region regionQuery = new Region {
                                                        RegionID = this.regionid  
                                                        };
                        
                        Region[]  regions = regionQuery.ToList();                        
                        if(regions.Length == 1)
                            this.regionRef = regions[0];                        
                    }
                    
                    return this.regionRef; 
                }
			set	{ 
                  if(this.regionRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("RegionRef"));
                        if (this.regionRef != null)
                            this.Parents.Remove(this.regionRef);                            
                        
                        if((this.regionRef = value) != null) 
                        {
                            this.Parents.Add(this.regionRef); 
                            this.regionid = this.regionRef.RegionID;
                        }
                        else
                        {
		                    this.regionid = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("RegionRef"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Territory entity = obj as Territory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.TerritoryID == entity.TerritoryID
                        && this.TerritoryID != default(string)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.territoryid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.territoryid = (string)reader[COL_TERRITORYID];
			this.territorydescription = (string)reader[COL_TERRITORYDESCRIPTION];
			this.regionid = (int)reader[COL_REGIONID];
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_TERRITORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryDescription, PARAM_TERRITORYDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_TERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryDescription, PARAM_TERRITORYDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_TERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
    }
}
