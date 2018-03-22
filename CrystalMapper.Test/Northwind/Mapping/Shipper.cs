/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Saturday, March 30, 2013 6:24 PM
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 *********************************************************************/

using System;
using System.Linq;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Linq;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Shipper : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Shippers";	
     
		public const string COL_SHIPPERID = "ShipperID";
		public const string COL_COMPANYNAME = "CompanyName";
		public const string COL_PHONE = "Phone";
		
        public const string PARAM_SHIPPERID = "@ShipperID";	
        public const string PARAM_COMPANYNAME = "@CompanyName";	
        public const string PARAM_PHONE = "@Phone";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHIPPERS = "INSERT INTO Shippers ( [CompanyName], [Phone]) VALUES ( @CompanyName, @Phone);"   + " SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_SHIPPERS = "UPDATE Shippers SET [CompanyName] = @CompanyName, [Phone] = @Phone WHERE [ShipperID] = @ShipperID";
		
		private const string SQL_DELETE_SHIPPERS = "DELETE FROM Shippers WHERE  [ShipperID] = @ShipperID ";
		
        #endregion
        	  	
        #region Declarations

		protected int shipperid = default(int);
	
		protected string companyname = default(string);
	
		protected string phone = default(string);
	
        
        private event PropertyChangingEventHandler propertyChanging;
        
        private event PropertyChangedEventHandler propertyChanged;
        #endregion

 		#region Properties
        
        event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add { this.propertyChanging += value; }
            remove { this.propertyChanging -= value; }
        }
        
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        { 
            add { this.propertyChanged += value; }
            remove { this.propertyChanged -= value; }
        }
        
        IQueryProvider IRecord.Provider { get; set; }

        [Column(COL_SHIPPERID, PARAM_SHIPPERID, default(int))]
        public virtual int ShipperID 
        {
            get { return this.shipperid; }
			set	{ 
                  if(this.shipperid != value)
                    {
                        this.OnPropertyChanging("ShipperID");  
                        this.shipperid = value;                        
                        this.OnPropertyChanged("ShipperID");
                    }   
                }
        }	
		
        [Column(COL_COMPANYNAME, PARAM_COMPANYNAME )]
        public virtual string CompanyName 
        {
            get { return this.companyname; }
			set	{ 
                  if(this.companyname != value)
                    {
                        this.OnPropertyChanging("CompanyName");  
                        this.companyname = value;                        
                        this.OnPropertyChanged("CompanyName");
                    }   
                }
        }	
		
        [Column(COL_PHONE, PARAM_PHONE )]
        public virtual string Phone 
        {
            get { return this.phone; }
			set	{ 
                  if(this.phone != value)
                    {
                        this.OnPropertyChanging("Phone");  
                        this.phone = value;                        
                        this.OnPropertyChanged("Phone");
                    }   
                }
        }	
       
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            Shipper record = obj as Shipper;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.ShipperID == record.ShipperID
                        && this.ShipperID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.shipperid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.shipperid = (int)reader[COL_SHIPPERID];
			this.companyname = (string)reader[COL_COMPANYNAME];
			this.phone = DbConvert.ToString(reader[COL_PHONE]);
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHIPPERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COMPANYNAME, this.CompanyName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHONE, DbConvert.DbValue(this.Phone)));
                this.ShipperID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHIPPERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPPERID, this.ShipperID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COMPANYNAME, this.CompanyName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHONE, DbConvert.DbValue(this.Phone)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHIPPERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPPERID, this.ShipperID));
                return (command.ExecuteNonQuery() == 1);
            }
        }
        
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if(this.propertyChanging != null)
                this.propertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.propertyChanged != null)
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}