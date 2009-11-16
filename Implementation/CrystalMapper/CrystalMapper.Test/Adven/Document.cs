/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Document
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
    public partial class Document : Entity< Document>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Document";	
     
		public const string COL_DOCUMENTNODE = "DocumentNode";
		public const string COL_DOCUMENTLEVEL = "DocumentLevel";
		public const string COL_TITLE = "Title";
		public const string COL_OWNER = "Owner";
		public const string COL_FOLDERFLAG = "FolderFlag";
		public const string COL_FILENAME = "FileName";
		public const string COL_FILEEXTENSION = "FileExtension";
		public const string COL_REVISION = "Revision";
		public const string COL_CHANGENUMBER = "ChangeNumber";
		public const string COL_STATUS = "Status";
		public const string COL_DOCUMENTSUMMARY = "DocumentSummary";
		public const string COL_DOCUMENT = "Document";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_DOCUMENTNODE = "@DocumentNode";	
        public const string PARAM_DOCUMENTLEVEL = "@DocumentLevel";	
        public const string PARAM_TITLE = "@Title";	
        public const string PARAM_OWNER = "@Owner";	
        public const string PARAM_FOLDERFLAG = "@FolderFlag";	
        public const string PARAM_FILENAME = "@FileName";	
        public const string PARAM_FILEEXTENSION = "@FileExtension";	
        public const string PARAM_REVISION = "@Revision";	
        public const string PARAM_CHANGENUMBER = "@ChangeNumber";	
        public const string PARAM_STATUS = "@Status";	
        public const string PARAM_DOCUMENTSUMMARY = "@DocumentSummary";	
        public const string PARAM_DOCUMENT = "@Document";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_DOCUMENT = "INSERT INTO Production.Document([DocumentNode],[DocumentLevel],[Title],[Owner],[FolderFlag],[FileName],[FileExtension],[Revision],[ChangeNumber],[Status],[DocumentSummary],[Document],[rowguid],[ModifiedDate]) VALUES (@DocumentNode,@DocumentLevel,@Title,@Owner,@FolderFlag,@FileName,@FileExtension,@Revision,@ChangeNumber,@Status,@DocumentSummary,@Document,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_DOCUMENT = "UPDATE Production.Document SET  [DocumentLevel] = @DocumentLevel, [Title] = @Title, [Owner] = @Owner, [FolderFlag] = @FolderFlag, [FileName] = @FileName, [FileExtension] = @FileExtension, [Revision] = @Revision, [ChangeNumber] = @ChangeNumber, [Status] = @Status, [DocumentSummary] = @DocumentSummary, [Document] = @Document, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [DocumentNode] = @DocumentNode";
		
		private const string SQL_DELETE_DOCUMENT = "DELETE FROM Production.Document WHERE  [DocumentNode] = @DocumentNode ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected object documentnode = default(object);
	
		protected short? documentlevel = default(short?);
	
		protected string title = default(string);
	
		protected int owner = default(int);
	
		protected bool folderflag = default(bool);
	
		protected string filename = default(string);
	
		protected string fileextension = default(string);
	
		protected string revision = default(string);
	
		protected int changenumber = default(int);
	
		protected byte status = default(byte);
	
		protected string documentsummary = default(string);
	
		protected byte[] document = default(byte[]);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Employee employeeEntity;
	
        protected EntityCollection< ProductDocument> productDocuments ;
        
        #endregion

 		#region Properties	

        [Column( COL_DOCUMENTNODE, PARAM_DOCUMENTNODE )]
                              public virtual object DocumentNode 
        {
            get { return this.documentnode; }
			set	{ 
                  if(this.documentnode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DocumentNode"));  
                        this.documentnode = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DocumentNode"));
                    }   
                }
        }	
		
        [Column( COL_DOCUMENTLEVEL, PARAM_DOCUMENTLEVEL )]
                              public virtual short? DocumentLevel 
        {
            get { return this.documentlevel; }
			set	{ 
                  if(this.documentlevel != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DocumentLevel"));  
                        this.documentlevel = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DocumentLevel"));
                    }   
                }
        }	
		
        [Column( COL_TITLE, PARAM_TITLE )]
                              public virtual string Title 
        {
            get { return this.title; }
			set	{ 
                  if(this.title != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Title"));  
                        this.title = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Title"));
                    }   
                }
        }	
		
        [Column( COL_FOLDERFLAG, PARAM_FOLDERFLAG, default(bool))]
                              public virtual bool FolderFlag 
        {
            get { return this.folderflag; }
			set	{ 
                  if(this.folderflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("FolderFlag"));  
                        this.folderflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("FolderFlag"));
                    }   
                }
        }	
		
        [Column( COL_FILENAME, PARAM_FILENAME )]
                              public virtual string FileName 
        {
            get { return this.filename; }
			set	{ 
                  if(this.filename != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("FileName"));  
                        this.filename = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("FileName"));
                    }   
                }
        }	
		
        [Column( COL_FILEEXTENSION, PARAM_FILEEXTENSION )]
                              public virtual string FileExtension 
        {
            get { return this.fileextension; }
			set	{ 
                  if(this.fileextension != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("FileExtension"));  
                        this.fileextension = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("FileExtension"));
                    }   
                }
        }	
		
        [Column( COL_REVISION, PARAM_REVISION )]
                              public virtual string Revision 
        {
            get { return this.revision; }
			set	{ 
                  if(this.revision != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Revision"));  
                        this.revision = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Revision"));
                    }   
                }
        }	
		
        [Column( COL_CHANGENUMBER, PARAM_CHANGENUMBER, default(int))]
                              public virtual int ChangeNumber 
        {
            get { return this.changenumber; }
			set	{ 
                  if(this.changenumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ChangeNumber"));  
                        this.changenumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ChangeNumber"));
                    }   
                }
        }	
		
        [Column( COL_STATUS, PARAM_STATUS, default(byte))]
                              public virtual byte Status 
        {
            get { return this.status; }
			set	{ 
                  if(this.status != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Status"));  
                        this.status = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Status"));
                    }   
                }
        }	
		
        [Column( COL_DOCUMENTSUMMARY, PARAM_DOCUMENTSUMMARY )]
                              public virtual string DocumentSummary 
        {
            get { return this.documentsummary; }
			set	{ 
                  if(this.documentsummary != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DocumentSummary"));  
                        this.documentsummary = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DocumentSummary"));
                    }   
                }
        }	
		
        [Column( COL_DOCUMENT, PARAM_DOCUMENT )]
                              public virtual byte[] DocumentBytes 
        {
            get { return this.document; }
			set	{ 
                  if(this.document != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DocumentBytes"));  
                        this.document = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DocumentBytes"));
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
		
        [Column( COL_OWNER, PARAM_OWNER, default(int))]
                              public virtual int Owner                
        {
            get
            {
                if(this.employeeEntity == null)
                    return this.owner ;
                
                return this.employeeEntity.BusinessEntityID;            
            }
            set
            {
                if(this.owner != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("Owner"));                    
                    this.owner = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Owner"));
                    
                    this.employeeEntity = null;
                }                
            }          
        }	
        
        public Employee EmployeeEntity
        {
            get { 
                    if(this.employeeEntity == null
                       && this.owner != default(int)) 
                    {
                        Employee employeeQuery = new Employee {
                                                        BusinessEntityID = this.owner  
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
                        
                        this.owner = this.EmployeeEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public EntityCollection< ProductDocument> ProductDocuments 
        {
            get { return this.productDocuments;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Document()
        {
             this.productDocuments = new EntityCollection< ProductDocument>(this, new Associate< ProductDocument>(this.AssociateProductDocuments), new DeAssociate< ProductDocument>(this.DeAssociateProductDocuments), new GetChildren< ProductDocument>(this.GetChildrenProductDocuments));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.documentnode.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Document entity = obj as Document;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.DocumentNode == entity.DocumentNode
                        && this.DocumentNode != default(object)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.documentnode = reader[COL_DOCUMENTNODE];
			this.documentlevel = DbConvert.ToNullable< short >(reader[COL_DOCUMENTLEVEL]);
			this.title = (string)reader[COL_TITLE];
			this.owner = (int)reader[COL_OWNER];
			this.folderflag = (bool)reader[COL_FOLDERFLAG];
			this.filename = (string)reader[COL_FILENAME];
			this.fileextension = (string)reader[COL_FILEEXTENSION];
			this.revision = (string)reader[COL_REVISION];
			this.changenumber = (int)reader[COL_CHANGENUMBER];
			this.status = (byte)reader[COL_STATUS];
			this.documentsummary = DbConvert.ToString(reader[COL_DOCUMENTSUMMARY]);
			this.document = (byte[])reader[COL_DOCUMENT];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_DOCUMENT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentNode, PARAM_DOCUMENTNODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentLevel), PARAM_DOCUMENTLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.Title, PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.Owner, PARAM_OWNER));
				command.Parameters.Add(dataContext.CreateParameter(this.FolderFlag, PARAM_FOLDERFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.FileName, PARAM_FILENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.FileExtension, PARAM_FILEEXTENSION));
				command.Parameters.Add(dataContext.CreateParameter(this.Revision, PARAM_REVISION));
				command.Parameters.Add(dataContext.CreateParameter(this.ChangeNumber, PARAM_CHANGENUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentSummary), PARAM_DOCUMENTSUMMARY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentBytes), PARAM_DOCUMENT));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_DOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentNode, PARAM_DOCUMENTNODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentLevel), PARAM_DOCUMENTLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.Title, PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.Owner, PARAM_OWNER));
				command.Parameters.Add(dataContext.CreateParameter(this.FolderFlag, PARAM_FOLDERFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.FileName, PARAM_FILENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.FileExtension, PARAM_FILEEXTENSION));
				command.Parameters.Add(dataContext.CreateParameter(this.Revision, PARAM_REVISION));
				command.Parameters.Add(dataContext.CreateParameter(this.ChangeNumber, PARAM_CHANGENUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentSummary), PARAM_DOCUMENTSUMMARY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentBytes), PARAM_DOCUMENT));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_DOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentNode, PARAM_DOCUMENTNODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProductDocuments(ProductDocument productDocument)
        {
           productDocument.DocumentEntity = this;
        }
        
        private void DeAssociateProductDocuments(ProductDocument productDocument)
        {
          if(productDocument.DocumentEntity == this)
             productDocument.DocumentEntity = null;
        }
        
        private ProductDocument[] GetChildrenProductDocuments()
        {
            ProductDocument childrenQuery = new ProductDocument();
            childrenQuery.DocumentEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
