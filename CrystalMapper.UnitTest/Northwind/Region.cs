/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:42 PM
 * 
 * Class: Region
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

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Region : Entity< Region>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Region";	
     
		public const string COL_REGIONID = "RegionID";
		public const string COL_REGIONDESCRIPTION = "RegionDescription";
		
        public const string PARAM_REGIONID = "@RegionID";	
        public const string PARAM_REGIONDESCRIPTION = "@RegionDescription";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_REGION = "INSERT INTO dbo.Region ( [RegionID], [RegionDescription]) VALUES ( @RegionID, @RegionDescription);"  ;
		
		private const string SQL_UPDATE_REGION = "UPDATE dbo.Region SET [RegionDescription] = @RegionDescription WHERE [RegionID] = @RegionID";
		
		private const string SQL_DELETE_REGION = "DELETE FROM dbo.Region WHERE  [RegionID] = @RegionID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int regionid = default(int);
	
		protected string regiondescription = default(string);
	
        #endregion

 		#region Properties	

        [Column( COL_REGIONID, PARAM_REGIONID, default(int))]
                              public virtual int RegionID 
        {
            get { return this.regionid; }
			set	{ 
                  if(this.regionid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("RegionID"));  
                        this.regionid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("RegionID"));
                    }   
                }
        }	
		
        [Column( COL_REGIONDESCRIPTION, PARAM_REGIONDESCRIPTION )]
                              public virtual string RegionDescription 
        {
            get { return this.regiondescription; }
			set	{ 
                  if(this.regiondescription != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("RegionDescription"));  
                        this.regiondescription = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("RegionDescription"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Region entity = obj as Region;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.RegionID == entity.RegionID
                        && this.RegionID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.regionid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.regionid = (int)reader[COL_REGIONID];
			this.regiondescription = (string)reader[COL_REGIONDESCRIPTION];
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_REGION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionDescription, PARAM_REGIONDESCRIPTION));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_REGION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionDescription, PARAM_REGIONDESCRIPTION));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_REGION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
    }
}
