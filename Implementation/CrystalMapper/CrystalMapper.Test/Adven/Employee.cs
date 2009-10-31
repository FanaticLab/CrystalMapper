/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Employee
 *    
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace CrystalMapper.Generated.BusinessObjects
{
	[Table(TABLE_NAME)]
    public partial class Employee : Entity< Employee>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.Employee";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_NATIONALIDNUMBER = "NationalIDNumber";
		public const string COL_CONTACTID = "ContactID";
		public const string COL_LOGINID = "LoginID";
		public const string COL_MANAGERID = "ManagerID";
		public const string COL_TITLE = "Title";
		public const string COL_BIRTHDATE = "BirthDate";
		public const string COL_MARITALSTATUS = "MaritalStatus";
		public const string COL_GENDER = "Gender";
		public const string COL_HIREDATE = "HireDate";
		public const string COL_SALARIEDFLAG = "SalariedFlag";
		public const string COL_VACATIONHOURS = "VacationHours";
		public const string COL_SICKLEAVEHOURS = "SickLeaveHours";
		public const string COL_CURRENTFLAG = "CurrentFlag";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_NATIONALIDNUMBER = "@NationalIDNumber";	
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_LOGINID = "@LoginID";	
        public const string PARAM_MANAGERID = "@ManagerID";	
        public const string PARAM_TITLE = "@Title";	
        public const string PARAM_BIRTHDATE = "@BirthDate";	
        public const string PARAM_MARITALSTATUS = "@MaritalStatus";	
        public const string PARAM_GENDER = "@Gender";	
        public const string PARAM_HIREDATE = "@HireDate";	
        public const string PARAM_SALARIEDFLAG = "@SalariedFlag";	
        public const string PARAM_VACATIONHOURS = "@VacationHours";	
        public const string PARAM_SICKLEAVEHOURS = "@SickLeaveHours";	
        public const string PARAM_CURRENTFLAG = "@CurrentFlag";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEE = "INSERT INTO HumanResources.Employee([NationalIDNumber],[ContactID],[LoginID],[ManagerID],[Title],[BirthDate],[MaritalStatus],[Gender],[HireDate],[SalariedFlag],[VacationHours],[SickLeaveHours],[CurrentFlag],[rowguid],[ModifiedDate]) VALUES (@NationalIDNumber,@ContactID,@LoginID,@ManagerID,@Title,@BirthDate,@MaritalStatus,@Gender,@HireDate,@SalariedFlag,@VacationHours,@SickLeaveHours,@CurrentFlag,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_EMPLOYEE = "UPDATE HumanResources.Employee SET [NationalIDNumber] = @NationalIDNumber, [ContactID] = @ContactID, [LoginID] = @LoginID, [ManagerID] = @ManagerID, [Title] = @Title, [BirthDate] = @BirthDate, [MaritalStatus] = @MaritalStatus, [Gender] = @Gender, [HireDate] = @HireDate, [SalariedFlag] = @SalariedFlag, [VacationHours] = @VacationHours, [SickLeaveHours] = @SickLeaveHours, [CurrentFlag] = @CurrentFlag, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [EmployeeID] = @EmployeeID";
		
		private const string SQL_DELETE_EMPLOYEE = "DELETE FROM HumanResources.Employee WHERE  [EmployeeID] = @EmployeeID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID  { get; set; }		
		
        
	    [Column( COL_NATIONALIDNUMBER, PARAM_NATIONALIDNUMBER )]
                              public virtual string NationalIDNumber  { get; set; }	      
        
	    [Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }	      
        
	    [Column( COL_LOGINID, PARAM_LOGINID )]
                              public virtual string LoginID  { get; set; }	      
        
	    [Column( COL_MANAGERID, PARAM_MANAGERID )]
                              public virtual int? ManagerID  { get; set; }	      
        
	    [Column( COL_TITLE, PARAM_TITLE )]
                              public virtual string Title  { get; set; }	      
        
	    [Column( COL_BIRTHDATE, PARAM_BIRTHDATE, typeof(System.DateTime))]
                              public virtual System.DateTime BirthDate  { get; set; }	      
        
	    [Column( COL_MARITALSTATUS, PARAM_MARITALSTATUS )]
                              public virtual string MaritalStatus  { get; set; }	      
        
	    [Column( COL_GENDER, PARAM_GENDER )]
                              public virtual string Gender  { get; set; }	      
        
	    [Column( COL_HIREDATE, PARAM_HIREDATE, typeof(System.DateTime))]
                              public virtual System.DateTime HireDate  { get; set; }	      
        
	    [Column( COL_SALARIEDFLAG, PARAM_SALARIEDFLAG, default(bool))]
                              public virtual bool SalariedFlag  { get; set; }	      
        
	    [Column( COL_VACATIONHOURS, PARAM_VACATIONHOURS, default(short))]
                              public virtual short VacationHours  { get; set; }	      
        
	    [Column( COL_SICKLEAVEHOURS, PARAM_SICKLEAVEHOURS, default(short))]
                              public virtual short SickLeaveHours  { get; set; }	      
        
	    [Column( COL_CURRENTFLAG, PARAM_CURRENTFLAG, default(bool))]
                              public virtual bool CurrentFlag  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< Employee> Employees
        {
            get {
                  foreach(Employee employee in EmployeeList())
                    yield return employee; 
                }
        }
        
        public IEnumerable< EmployeeAddress> EmployeeAddresses
        {
            get {
                  foreach(EmployeeAddress employeeAddress in EmployeeAddressList())
                    yield return employeeAddress; 
                }
        }
        
        public IEnumerable< EmployeeDepartmentHistory> EmployeeDepartmentHistories
        {
            get {
                  foreach(EmployeeDepartmentHistory employeeDepartmentHistory in EmployeeDepartmentHistoryList())
                    yield return employeeDepartmentHistory; 
                }
        }
        
        public IEnumerable< EmployeePayHistory> EmployeePayHistories
        {
            get {
                  foreach(EmployeePayHistory employeePayHistory in EmployeePayHistoryList())
                    yield return employeePayHistory; 
                }
        }
        
        public IEnumerable< JobCandidate> JobCandidates
        {
            get {
                  foreach(JobCandidate jobCandidate in JobCandidateList())
                    yield return jobCandidate; 
                }
        }
        
        public IEnumerable< PurchaseOrderHeader> PurchaseOrderHeaders
        {
            get {
                  foreach(PurchaseOrderHeader purchaseOrderHeader in PurchaseOrderHeaderList())
                    yield return purchaseOrderHeader; 
                }
        }
        
        public IEnumerable< SalesPerson> SalesPeople
        {
            get {
                  foreach(SalesPerson salesPerson in SalesPersonList())
                    yield return salesPerson; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.EmployeeID = (int)reader[COL_EMPLOYEEID];
			this.NationalIDNumber = (string)reader[COL_NATIONALIDNUMBER];
			this.ContactID = (int)reader[COL_CONTACTID];
			this.LoginID = (string)reader[COL_LOGINID];
			this.ManagerID = DbConvert.ToNullable< int >(reader[COL_MANAGERID]);
			this.Title = (string)reader[COL_TITLE];
			this.BirthDate = (System.DateTime)reader[COL_BIRTHDATE];
			this.MaritalStatus = (string)reader[COL_MARITALSTATUS];
			this.Gender = (string)reader[COL_GENDER];
			this.HireDate = (System.DateTime)reader[COL_HIREDATE];
			this.SalariedFlag = (bool)reader[COL_SALARIEDFLAG];
			this.VacationHours = (short)reader[COL_VACATIONHOURS];
			this.SickLeaveHours = (short)reader[COL_SICKLEAVEHOURS];
			this.CurrentFlag = (bool)reader[COL_CURRENTFLAG];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.NationalIDNumber, PARAM_NATIONALIDNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.LoginID, PARAM_LOGINID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ManagerID), PARAM_MANAGERID));
				command.Parameters.Add(dataContext.CreateParameter(this.Title, PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.BirthDate, PARAM_BIRTHDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MaritalStatus, PARAM_MARITALSTATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.Gender, PARAM_GENDER));
				command.Parameters.Add(dataContext.CreateParameter(this.HireDate, PARAM_HIREDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.SalariedFlag, PARAM_SALARIEDFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.VacationHours, PARAM_VACATIONHOURS));
				command.Parameters.Add(dataContext.CreateParameter(this.SickLeaveHours, PARAM_SICKLEAVEHOURS));
				command.Parameters.Add(dataContext.CreateParameter(this.CurrentFlag, PARAM_CURRENTFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.EmployeeID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.NationalIDNumber, PARAM_NATIONALIDNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.LoginID, PARAM_LOGINID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ManagerID), PARAM_MANAGERID));
				command.Parameters.Add(dataContext.CreateParameter(this.Title, PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.BirthDate, PARAM_BIRTHDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MaritalStatus, PARAM_MARITALSTATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.Gender, PARAM_GENDER));
				command.Parameters.Add(dataContext.CreateParameter(this.HireDate, PARAM_HIREDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.SalariedFlag, PARAM_SALARIEDFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.VacationHours, PARAM_VACATIONHOURS));
				command.Parameters.Add(dataContext.CreateParameter(this.SickLeaveHours, PARAM_SICKLEAVEHOURS));
				command.Parameters.Add(dataContext.CreateParameter(this.CurrentFlag, PARAM_CURRENTFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public Employee GetEmployeesQuery()
        {
            return new Employee {                
                                                                            ManagerID = this.EmployeeID  
                                                                            };
        }
        
        public Employee[] EmployeeList()
        {
            return GetEmployeesQuery().ToList();
        }  
        
        public EmployeeAddress GetEmployeeAddressesQuery()
        {
            return new EmployeeAddress {                
                                                                            EmployeeID = this.EmployeeID  
                                                                            };
        }
        
        public EmployeeAddress[] EmployeeAddressList()
        {
            return GetEmployeeAddressesQuery().ToList();
        }  
        
        public EmployeeDepartmentHistory GetEmployeeDepartmentHistoriesQuery()
        {
            return new EmployeeDepartmentHistory {                
                                                                            EmployeeID = this.EmployeeID  
                                                                            };
        }
        
        public EmployeeDepartmentHistory[] EmployeeDepartmentHistoryList()
        {
            return GetEmployeeDepartmentHistoriesQuery().ToList();
        }  
        
        public EmployeePayHistory GetEmployeePayHistoriesQuery()
        {
            return new EmployeePayHistory {                
                                                                            EmployeeID = this.EmployeeID  
                                                                            };
        }
        
        public EmployeePayHistory[] EmployeePayHistoryList()
        {
            return GetEmployeePayHistoriesQuery().ToList();
        }  
        
        public JobCandidate GetJobCandidatesQuery()
        {
            return new JobCandidate {                
                                                                            EmployeeID = this.EmployeeID  
                                                                            };
        }
        
        public JobCandidate[] JobCandidateList()
        {
            return GetJobCandidatesQuery().ToList();
        }  
        
        public PurchaseOrderHeader GetPurchaseOrderHeadersQuery()
        {
            return new PurchaseOrderHeader {                
                                                                            EmployeeID = this.EmployeeID  
                                                                            };
        }
        
        public PurchaseOrderHeader[] PurchaseOrderHeaderList()
        {
            return GetPurchaseOrderHeadersQuery().ToList();
        }  
        
        public SalesPerson GetSalesPeopleQuery()
        {
            return new SalesPerson {                
                                                                            SalesPersonID = this.EmployeeID  
                                                                            };
        }
        
        public SalesPerson[] SalesPersonList()
        {
            return GetSalesPeopleQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
