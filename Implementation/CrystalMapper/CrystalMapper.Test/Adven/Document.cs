/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Document
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
    public partial class Document : Entity< Document>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Document";	
     
		public const string COL_DOCUMENTID = "DocumentID";
		public const string COL_TITLE = "Title";
		public const string COL_FILENAME = "FileName";
		public const string COL_FILEEXTENSION = "FileExtension";
		public const string COL_REVISION = "Revision";
		public const string COL_CHANGENUMBER = "ChangeNumber";
		public const string COL_STATUS = "Status";
		public const string COL_DOCUMENTSUMMARY = "DocumentSummary";
		public const string COL_DOCUMENT = "Document";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_DOCUMENTID = "@DocumentID";	
        public const string PARAM_TITLE = "@Title";	
        public const string PARAM_FILENAME = "@FileName";	
        public const string PARAM_FILEEXTENSION = "@FileExtension";	
        public const string PARAM_REVISION = "@Revision";	
        public const string PARAM_CHANGENUMBER = "@ChangeNumber";	
        public const string PARAM_STATUS = "@Status";	
        public const string PARAM_DOCUMENTSUMMARY = "@DocumentSummary";	
        public const string PARAM_DOCUMENT = "@Document";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_DOCUMENT = "INSERT INTO Production.Document([Title],[FileName],[FileExtension],[Revision],[ChangeNumber],[Status],[DocumentSummary],[Document],[ModifiedDate]) VALUES (@Title,@FileName,@FileExtension,@Revision,@ChangeNumber,@Status,@DocumentSummary,@Document,@ModifiedDate);";
		
		private const string SQL_UPDATE_DOCUMENT = "UPDATE Production.Document SET [Title] = @Title, [FileName] = @FileName, [FileExtension] = @FileExtension, [Revision] = @Revision, [ChangeNumber] = @ChangeNumber, [Status] = @Status, [DocumentSummary] = @DocumentSummary, [Document] = @Document, [ModifiedDate] = @ModifiedDate,  WHERE [DocumentID] = @DocumentID";
		
		private const string SQL_DELETE_DOCUMENT = "DELETE FROM Production.Document WHERE  [DocumentID] = @DocumentID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_DOCUMENTID, PARAM_DOCUMENTID, default(int))]
                              public virtual int DocumentID  { get; set; }		
		
        
	    [Column( COL_TITLE, PARAM_TITLE )]
                              public virtual string Title  { get; set; }	      
        
	    [Column( COL_FILENAME, PARAM_FILENAME )]
                              public virtual string FileName  { get; set; }	      
        
	    [Column( COL_FILEEXTENSION, PARAM_FILEEXTENSION )]
                              public virtual string FileExtension  { get; set; }	      
        
	    [Column( COL_REVISION, PARAM_REVISION )]
                              public virtual string Revision  { get; set; }	      
        
	    [Column( COL_CHANGENUMBER, PARAM_CHANGENUMBER, default(int))]
                              public virtual int ChangeNumber  { get; set; }	      
        
	    [Column( COL_STATUS, PARAM_STATUS, default(byte))]
                              public virtual byte Status  { get; set; }	      
        
	    [Column( COL_DOCUMENTSUMMARY, PARAM_DOCUMENTSUMMARY )]
                              public virtual string DocumentSummary  { get; set; }	      
        
	    [Column( COL_DOCUMENT, PARAM_DOCUMENT )]
                              public virtual byte[] DocumentBytes  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ProductDocument> ProductDocuments
        {
            get {
                  foreach(ProductDocument productDocument in ProductDocumentList())
                    yield return productDocument; 
                }
        }
        
        
        public IEnumerable< Product> Products
        {
            get {           
                
                foreach(Product product in ProductList())
                    yield return product; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.DocumentID = (int)reader[COL_DOCUMENTID];
			this.Title = (string)reader[COL_TITLE];
			this.FileName = (string)reader[COL_FILENAME];
			this.FileExtension = (string)reader[COL_FILEEXTENSION];
			this.Revision = (string)reader[COL_REVISION];
			this.ChangeNumber = (int)reader[COL_CHANGENUMBER];
			this.Status = (byte)reader[COL_STATUS];
			this.DocumentSummary = DbConvert.ToString(reader[COL_DOCUMENTSUMMARY]);
			this.DocumentBytes = (byte[])reader[COL_DOCUMENT];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_DOCUMENT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Title, PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.FileName, PARAM_FILENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.FileExtension, PARAM_FILEEXTENSION));
				command.Parameters.Add(dataContext.CreateParameter(this.Revision, PARAM_REVISION));
				command.Parameters.Add(dataContext.CreateParameter(this.ChangeNumber, PARAM_CHANGENUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentSummary), PARAM_DOCUMENTSUMMARY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentBytes), PARAM_DOCUMENT));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.DocumentID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_DOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentID, PARAM_DOCUMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Title, PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.FileName, PARAM_FILENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.FileExtension, PARAM_FILEEXTENSION));
				command.Parameters.Add(dataContext.CreateParameter(this.Revision, PARAM_REVISION));
				command.Parameters.Add(dataContext.CreateParameter(this.ChangeNumber, PARAM_CHANGENUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentSummary), PARAM_DOCUMENTSUMMARY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DocumentBytes), PARAM_DOCUMENT));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_DOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentID, PARAM_DOCUMENTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public ProductDocument GetProductDocumentsQuery()
        {
            return new ProductDocument {                
                                                                            DocumentID = this.DocumentID  
                                                                            };
        }
        
        public ProductDocument[] ProductDocumentList()
        {
            return GetProductDocumentsQuery().ToList();
        }  
        
        
        
        public Product[] ProductList()
        {
            string sqlQuery = @"SELECT Production.Product.*
                                FROM Production.ProductDocument
                                INNER JOIN Production.Product ON                                                                            
                                Production.ProductDocument.[ProductID] = Production.Product.[ProductID] AND
                                Production.ProductDocument.[DocumentID] = @DocumentID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_DOCUMENTID, this.DocumentID);
            
            return Product.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
