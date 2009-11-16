/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: EmployeePayHistory
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
    public partial class EmployeePayHistory : Entity< EmployeePayHistory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.EmployeePayHistory";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_RATECHANGEDATE = "RateChangeDate";
		public const string COL_RATE = "Rate";
		public const string COL_PAYFREQUENCY = "PayFrequency";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_RATECHANGEDATE = "@RateChangeDate";	
        public const string PARAM_RATE = "@Rate";	
        public const string PARAM_PAYFREQUENCY = "@PayFrequency";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEEPAYHISTORY = "INSERT INTO HumanResources.EmployeePayHistory([BusinessEntityID],[RateChangeDate],[Rate],[PayFrequency],[ModifiedDate]) VALUES (@BusinessEntityID,@RateChangeDate,@Rate,@PayFrequency,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_EMPLOYEEPAYHISTORY = "UPDATE HumanResources.EmployeePayHistory SET  [Rate] = @Rate, [PayFrequency] = @PayFrequency, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID AND [RateChangeDate] = @RateChangeDate";
		
		private const string SQL_DELETE_EMPLOYEEPAYHISTORY = "DELETE FROM HumanResources.EmployeePayHistory WHERE  [BusinessEntityID] = @BusinessEntityID AND [RateChangeDate] = @RateChangeDate ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected System.DateTime ratechangedate = default(System.DateTime);
	
		protected decimal rate = default(decimal);
	
		protected byte payfrequency = default(byte);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Employee employeeEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_RATECHANGEDATE, PARAM_RATECHANGEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime RateChangeDate 
        {
            get { return this.ratechangedate; }
			set	{ 
                  if(this.ratechangedate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("RateChangeDate"));  
                        this.ratechangedate = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("RateChangeDate"));
                    }   
                }
        }	
		
        [Column( COL_RATE, PARAM_RATE, typeof(decimal))]
                              public virtual decimal Rate 
        {
            get { return this.rate; }
			set	{ 
                  if(this.rate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rate"));  
                        this.rate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rate"));
                    }   
                }
        }	
		
        [Column( COL_PAYFREQUENCY, PARAM_PAYFREQUENCY, default(byte))]
                              public virtual byte PayFrequency 
        {
            get { return this.payfrequency; }
			set	{ 
                  if(this.payfrequency != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PayFrequency"));  
                        this.payfrequency = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PayFrequency"));
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
		
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.employeeEntity == null)
                    return this.businessentityid ;
                
                return this.employeeEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.employeeEntity = null;
                }                
            }          
        }	
        
        public Employee EmployeeEntity
        {
            get { 
                    if(this.employeeEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        Employee employeeQuery = new Employee {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        Employee[]  employees = employeeQuery.ToList();                        
                        if(employees.Length == 1)
                            this.employeeEntity = employees[0];                        
                    }
                    
                    return this.employeeEntity; 
                }
			set	{ 
                  if(this.employeeEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeEntity"));
                        if (this.employeeEntity != null)
                            this.Parents.Remove(this.employeeEntity);                            
                        
                        if((this.employeeEntity = value) != null) 
                            this.Parents.Add(this.employeeEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeEntity"));
                        
                        this.businessentityid = this.EmployeeEntity.BusinessEntityID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public EmployeePayHistory()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                result = (11 * result) + this.ratechangedate.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            EmployeePayHistory entity = obj as EmployeePayHistory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.RateChangeDate == entity.RateChangeDate
                        && this.BusinessEntityID != default(int)
                        && this.RateChangeDate != default(System.DateTime)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.ratechangedate = (System.DateTime)reader[COL_RATECHANGEDATE];
			this.rate = (decimal)reader[COL_RATE];
			this.payfrequency = (byte)reader[COL_PAYFREQUENCY];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEEPAYHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.RateChangeDate, PARAM_RATECHANGEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rate, PARAM_RATE));
				command.Parameters.Add(dataContext.CreateParameter(this.PayFrequency, PARAM_PAYFREQUENCY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEEPAYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.RateChangeDate, PARAM_RATECHANGEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rate, PARAM_RATE));
				command.Parameters.Add(dataContext.CreateParameter(this.PayFrequency, PARAM_PAYFREQUENCY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEEPAYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
				command.Parameters.Add(dataContext.CreateParameter(this.RateChangeDate, PARAM_RATECHANGEDATE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
