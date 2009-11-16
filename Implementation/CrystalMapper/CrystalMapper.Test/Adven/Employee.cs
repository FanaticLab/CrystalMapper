/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Employee
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
    public partial class Employee : Entity< Employee>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.Employee";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_NATIONALIDNUMBER = "NationalIDNumber";
		public const string COL_LOGINID = "LoginID";
		public const string COL_ORGANIZATIONNODE = "OrganizationNode";
		public const string COL_ORGANIZATIONLEVEL = "OrganizationLevel";
		public const string COL_JOBTITLE = "JobTitle";
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
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_NATIONALIDNUMBER = "@NationalIDNumber";	
        public const string PARAM_LOGINID = "@LoginID";	
        public const string PARAM_ORGANIZATIONNODE = "@OrganizationNode";	
        public const string PARAM_ORGANIZATIONLEVEL = "@OrganizationLevel";	
        public const string PARAM_JOBTITLE = "@JobTitle";	
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
		
		private const string SQL_INSERT_EMPLOYEE = "INSERT INTO HumanResources.Employee([BusinessEntityID],[NationalIDNumber],[LoginID],[OrganizationNode],[OrganizationLevel],[JobTitle],[BirthDate],[MaritalStatus],[Gender],[HireDate],[SalariedFlag],[VacationHours],[SickLeaveHours],[CurrentFlag],[rowguid],[ModifiedDate]) VALUES (@BusinessEntityID,@NationalIDNumber,@LoginID,@OrganizationNode,@OrganizationLevel,@JobTitle,@BirthDate,@MaritalStatus,@Gender,@HireDate,@SalariedFlag,@VacationHours,@SickLeaveHours,@CurrentFlag,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_EMPLOYEE = "UPDATE HumanResources.Employee SET  [NationalIDNumber] = @NationalIDNumber, [LoginID] = @LoginID, [OrganizationNode] = @OrganizationNode, [OrganizationLevel] = @OrganizationLevel, [JobTitle] = @JobTitle, [BirthDate] = @BirthDate, [MaritalStatus] = @MaritalStatus, [Gender] = @Gender, [HireDate] = @HireDate, [SalariedFlag] = @SalariedFlag, [VacationHours] = @VacationHours, [SickLeaveHours] = @SickLeaveHours, [CurrentFlag] = @CurrentFlag, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID";
		
		private const string SQL_DELETE_EMPLOYEE = "DELETE FROM HumanResources.Employee WHERE  [BusinessEntityID] = @BusinessEntityID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected string nationalidnumber = default(string);
	
		protected string loginid = default(string);
	
		protected object organizationnode = default(object);
	
		protected short? organizationlevel = default(short?);
	
		protected string jobtitle = default(string);
	
		protected System.DateTime birthdate = default(System.DateTime);
	
		protected string maritalstatus = default(string);
	
		protected string gender = default(string);
	
		protected System.DateTime hiredate = default(System.DateTime);
	
		protected bool salariedflag = default(bool);
	
		protected short vacationhour = default(short);
	
		protected short sickleavehour = default(short);
	
		protected bool currentflag = default(bool);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Person personEntity;
	
        protected EntityCollection< EmployeeDepartmentHistory> employeeDepartmentHistories ;
        
        protected EntityCollection< EmployeePayHistory> employeePayHistories ;
        
        protected EntityCollection< JobCandidate> jobCandidates ;
        
        protected EntityCollection< Document> documents ;
        
        protected EntityCollection< PurchaseOrderHeader> purchaseOrderHeaders ;
        
        protected EntityCollection< SalesPerson> salesPeople ;
        
        #endregion

 		#region Properties	

        [Column( COL_NATIONALIDNUMBER, PARAM_NATIONALIDNUMBER )]
                              public virtual string NationalIDNumber 
        {
            get { return this.nationalidnumber; }
			set	{ 
                  if(this.nationalidnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("NationalIDNumber"));  
                        this.nationalidnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("NationalIDNumber"));
                    }   
                }
        }	
		
        [Column( COL_LOGINID, PARAM_LOGINID )]
                              public virtual string LoginID 
        {
            get { return this.loginid; }
			set	{ 
                  if(this.loginid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LoginID"));  
                        this.loginid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LoginID"));
                    }   
                }
        }	
		
        [Column( COL_ORGANIZATIONNODE, PARAM_ORGANIZATIONNODE )]
                              public virtual object OrganizationNode 
        {
            get { return this.organizationnode; }
			set	{ 
                  if(this.organizationnode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OrganizationNode"));  
                        this.organizationnode = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OrganizationNode"));
                    }   
                }
        }	
		
        [Column( COL_ORGANIZATIONLEVEL, PARAM_ORGANIZATIONLEVEL )]
                              public virtual short? OrganizationLevel 
        {
            get { return this.organizationlevel; }
			set	{ 
                  if(this.organizationlevel != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OrganizationLevel"));  
                        this.organizationlevel = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OrganizationLevel"));
                    }   
                }
        }	
		
        [Column( COL_JOBTITLE, PARAM_JOBTITLE )]
                              public virtual string JobTitle 
        {
            get { return this.jobtitle; }
			set	{ 
                  if(this.jobtitle != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("JobTitle"));  
                        this.jobtitle = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("JobTitle"));
                    }   
                }
        }	
		
        [Column( COL_BIRTHDATE, PARAM_BIRTHDATE, typeof(System.DateTime))]
                              public virtual System.DateTime BirthDate 
        {
            get { return this.birthdate; }
			set	{ 
                  if(this.birthdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("BirthDate"));  
                        this.birthdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("BirthDate"));
                    }   
                }
        }	
		
        [Column( COL_MARITALSTATUS, PARAM_MARITALSTATUS )]
                              public virtual string MaritalStatus 
        {
            get { return this.maritalstatus; }
			set	{ 
                  if(this.maritalstatus != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("MaritalStatus"));  
                        this.maritalstatus = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("MaritalStatus"));
                    }   
                }
        }	
		
        [Column( COL_GENDER, PARAM_GENDER )]
                              public virtual string Gender 
        {
            get { return this.gender; }
			set	{ 
                  if(this.gender != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Gender"));  
                        this.gender = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Gender"));
                    }   
                }
        }	
		
        [Column( COL_HIREDATE, PARAM_HIREDATE, typeof(System.DateTime))]
                              public virtual System.DateTime HireDate 
        {
            get { return this.hiredate; }
			set	{ 
                  if(this.hiredate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("HireDate"));  
                        this.hiredate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("HireDate"));
                    }   
                }
        }	
		
        [Column( COL_SALARIEDFLAG, PARAM_SALARIEDFLAG, default(bool))]
                              public virtual bool SalariedFlag 
        {
            get { return this.salariedflag; }
			set	{ 
                  if(this.salariedflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalariedFlag"));  
                        this.salariedflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalariedFlag"));
                    }   
                }
        }	
		
        [Column( COL_VACATIONHOURS, PARAM_VACATIONHOURS, default(short))]
                              public virtual short VacationHours 
        {
            get { return this.vacationhour; }
			set	{ 
                  if(this.vacationhour != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("VacationHours"));  
                        this.vacationhour = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("VacationHours"));
                    }   
                }
        }	
		
        [Column( COL_SICKLEAVEHOURS, PARAM_SICKLEAVEHOURS, default(short))]
                              public virtual short SickLeaveHours 
        {
            get { return this.sickleavehour; }
			set	{ 
                  if(this.sickleavehour != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SickLeaveHours"));  
                        this.sickleavehour = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SickLeaveHours"));
                    }   
                }
        }	
		
        [Column( COL_CURRENTFLAG, PARAM_CURRENTFLAG, default(bool))]
                              public virtual bool CurrentFlag 
        {
            get { return this.currentflag; }
			set	{ 
                  if(this.currentflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CurrentFlag"));  
                        this.currentflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentFlag"));
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
		
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.personEntity == null)
                    return this.businessentityid ;
                
                return this.personEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.personEntity = null;
                }                
            }          
        }	
        
        public Person PersonEntity
        {
            get { 
                    if(this.personEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        Person personQuery = new Person {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        Person[]  people = personQuery.ToList();                        
                        if(people.Length == 1)
                            this.personEntity = people[0];                        
                    }
                    
                    return this.personEntity; 
                }
			set	{ 
                  if(this.personEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PersonEntity"));
                        if (this.personEntity != null)
                            this.Parents.Remove(this.personEntity);                            
                        
                        if((this.personEntity = value) != null) 
                            this.Parents.Add(this.personEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PersonEntity"));
                        
                        this.businessentityid = this.PersonEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public EntityCollection< EmployeeDepartmentHistory> EmployeeDepartmentHistories 
        {
            get { return this.employeeDepartmentHistories;}
        }
        
        public EntityCollection< EmployeePayHistory> EmployeePayHistories 
        {
            get { return this.employeePayHistories;}
        }
        
        public EntityCollection< JobCandidate> JobCandidates 
        {
            get { return this.jobCandidates;}
        }
        
        public EntityCollection< Document> Documents 
        {
            get { return this.documents;}
        }
        
        public EntityCollection< PurchaseOrderHeader> PurchaseOrderHeaders 
        {
            get { return this.purchaseOrderHeaders;}
        }
        
        public EntityCollection< SalesPerson> SalesPeople 
        {
            get { return this.salesPeople;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Employee()
        {
             this.employeeDepartmentHistories = new EntityCollection< EmployeeDepartmentHistory>(this, new Associate< EmployeeDepartmentHistory>(this.AssociateEmployeeDepartmentHistories), new DeAssociate< EmployeeDepartmentHistory>(this.DeAssociateEmployeeDepartmentHistories), new GetChildren< EmployeeDepartmentHistory>(this.GetChildrenEmployeeDepartmentHistories));
             this.employeePayHistories = new EntityCollection< EmployeePayHistory>(this, new Associate< EmployeePayHistory>(this.AssociateEmployeePayHistories), new DeAssociate< EmployeePayHistory>(this.DeAssociateEmployeePayHistories), new GetChildren< EmployeePayHistory>(this.GetChildrenEmployeePayHistories));
             this.jobCandidates = new EntityCollection< JobCandidate>(this, new Associate< JobCandidate>(this.AssociateJobCandidates), new DeAssociate< JobCandidate>(this.DeAssociateJobCandidates), new GetChildren< JobCandidate>(this.GetChildrenJobCandidates));
             this.documents = new EntityCollection< Document>(this, new Associate< Document>(this.AssociateDocuments), new DeAssociate< Document>(this.DeAssociateDocuments), new GetChildren< Document>(this.GetChildrenDocuments));
             this.purchaseOrderHeaders = new EntityCollection< PurchaseOrderHeader>(this, new Associate< PurchaseOrderHeader>(this.AssociatePurchaseOrderHeaders), new DeAssociate< PurchaseOrderHeader>(this.DeAssociatePurchaseOrderHeaders), new GetChildren< PurchaseOrderHeader>(this.GetChildrenPurchaseOrderHeaders));
             this.salesPeople = new EntityCollection< SalesPerson>(this, new Associate< SalesPerson>(this.AssociateSalesPeople), new DeAssociate< SalesPerson>(this.DeAssociateSalesPeople), new GetChildren< SalesPerson>(this.GetChildrenSalesPeople));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Employee entity = obj as Employee;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.BusinessEntityID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.nationalidnumber = (string)reader[COL_NATIONALIDNUMBER];
			this.loginid = (string)reader[COL_LOGINID];
			this.organizationnode = reader[COL_ORGANIZATIONNODE];
			this.organizationlevel = DbConvert.ToNullable< short >(reader[COL_ORGANIZATIONLEVEL]);
			this.jobtitle = (string)reader[COL_JOBTITLE];
			this.birthdate = (System.DateTime)reader[COL_BIRTHDATE];
			this.maritalstatus = (string)reader[COL_MARITALSTATUS];
			this.gender = (string)reader[COL_GENDER];
			this.hiredate = (System.DateTime)reader[COL_HIREDATE];
			this.salariedflag = (bool)reader[COL_SALARIEDFLAG];
			this.vacationhour = (short)reader[COL_VACATIONHOURS];
			this.sickleavehour = (short)reader[COL_SICKLEAVEHOURS];
			this.currentflag = (bool)reader[COL_CURRENTFLAG];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.NationalIDNumber, PARAM_NATIONALIDNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.LoginID, PARAM_LOGINID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrganizationNode), PARAM_ORGANIZATIONNODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrganizationLevel), PARAM_ORGANIZATIONLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.JobTitle, PARAM_JOBTITLE));
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

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.NationalIDNumber, PARAM_NATIONALIDNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.LoginID, PARAM_LOGINID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrganizationNode), PARAM_ORGANIZATIONNODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrganizationLevel), PARAM_ORGANIZATIONLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.JobTitle, PARAM_JOBTITLE));
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
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateEmployeeDepartmentHistories(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
           employeeDepartmentHistory.EmployeeEntity = this;
        }
        
        private void DeAssociateEmployeeDepartmentHistories(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
          if(employeeDepartmentHistory.EmployeeEntity == this)
             employeeDepartmentHistory.EmployeeEntity = null;
        }
        
        private EmployeeDepartmentHistory[] GetChildrenEmployeeDepartmentHistories()
        {
            EmployeeDepartmentHistory childrenQuery = new EmployeeDepartmentHistory();
            childrenQuery.EmployeeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateEmployeePayHistories(EmployeePayHistory employeePayHistory)
        {
           employeePayHistory.EmployeeEntity = this;
        }
        
        private void DeAssociateEmployeePayHistories(EmployeePayHistory employeePayHistory)
        {
          if(employeePayHistory.EmployeeEntity == this)
             employeePayHistory.EmployeeEntity = null;
        }
        
        private EmployeePayHistory[] GetChildrenEmployeePayHistories()
        {
            EmployeePayHistory childrenQuery = new EmployeePayHistory();
            childrenQuery.EmployeeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateJobCandidates(JobCandidate jobCandidate)
        {
           jobCandidate.EmployeeEntity = this;
        }
        
        private void DeAssociateJobCandidates(JobCandidate jobCandidate)
        {
          if(jobCandidate.EmployeeEntity == this)
             jobCandidate.EmployeeEntity = null;
        }
        
        private JobCandidate[] GetChildrenJobCandidates()
        {
            JobCandidate childrenQuery = new JobCandidate();
            childrenQuery.EmployeeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateDocuments(Document document)
        {
           document.EmployeeEntity = this;
        }
        
        private void DeAssociateDocuments(Document document)
        {
          if(document.EmployeeEntity == this)
             document.EmployeeEntity = null;
        }
        
        private Document[] GetChildrenDocuments()
        {
            Document childrenQuery = new Document();
            childrenQuery.EmployeeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociatePurchaseOrderHeaders(PurchaseOrderHeader purchaseOrderHeader)
        {
           purchaseOrderHeader.EmployeeEntity = this;
        }
        
        private void DeAssociatePurchaseOrderHeaders(PurchaseOrderHeader purchaseOrderHeader)
        {
          if(purchaseOrderHeader.EmployeeEntity == this)
             purchaseOrderHeader.EmployeeEntity = null;
        }
        
        private PurchaseOrderHeader[] GetChildrenPurchaseOrderHeaders()
        {
            PurchaseOrderHeader childrenQuery = new PurchaseOrderHeader();
            childrenQuery.EmployeeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesPeople(SalesPerson salesPerson)
        {
           salesPerson.EmployeeEntity = this;
        }
        
        private void DeAssociateSalesPeople(SalesPerson salesPerson)
        {
          if(salesPerson.EmployeeEntity == this)
             salesPerson.EmployeeEntity = null;
        }
        
        private SalesPerson[] GetChildrenSalesPeople()
        {
            SalesPerson childrenQuery = new SalesPerson();
            childrenQuery.EmployeeEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
