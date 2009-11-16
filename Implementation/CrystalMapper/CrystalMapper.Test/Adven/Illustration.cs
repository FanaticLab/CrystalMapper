/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Illustration
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
    public partial class Illustration : Entity< Illustration>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Illustration";	
     
		public const string COL_ILLUSTRATIONID = "IllustrationID";
		public const string COL_DIAGRAM = "Diagram";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_ILLUSTRATIONID = "@IllustrationID";	
        public const string PARAM_DIAGRAM = "@Diagram";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ILLUSTRATION = "INSERT INTO Production.Illustration([Diagram],[ModifiedDate]) VALUES (@Diagram,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_ILLUSTRATION = "UPDATE Production.Illustration SET  [Diagram] = @Diagram, [ModifiedDate] = @ModifiedDate WHERE [IllustrationID] = @IllustrationID";
		
		private const string SQL_DELETE_ILLUSTRATION = "DELETE FROM Production.Illustration WHERE  [IllustrationID] = @IllustrationID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int illustrationid = default(int);
	
		protected System.Xml.XmlDocument diagram = default(System.Xml.XmlDocument);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< ProductModelIllustration> productModelIllustrations ;
        
        #endregion

 		#region Properties	

        [Column( COL_ILLUSTRATIONID, PARAM_ILLUSTRATIONID, default(int))]
                              public virtual int IllustrationID 
        {
            get { return this.illustrationid; }
			set	{ 
                  if(this.illustrationid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("IllustrationID"));  
                        this.illustrationid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("IllustrationID"));
                    }   
                }
        }	
		
        [Column( COL_DIAGRAM, PARAM_DIAGRAM )]
                              public virtual System.Xml.XmlDocument Diagram 
        {
            get { return this.diagram; }
			set	{ 
                  if(this.diagram != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Diagram"));  
                        this.diagram = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Diagram"));
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
		
        public EntityCollection< ProductModelIllustration> ProductModelIllustrations 
        {
            get { return this.productModelIllustrations;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Illustration()
        {
             this.productModelIllustrations = new EntityCollection< ProductModelIllustration>(this, new Associate< ProductModelIllustration>(this.AssociateProductModelIllustrations), new DeAssociate< ProductModelIllustration>(this.DeAssociateProductModelIllustrations), new GetChildren< ProductModelIllustration>(this.GetChildrenProductModelIllustrations));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.illustrationid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Illustration entity = obj as Illustration;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.IllustrationID == entity.IllustrationID
                        && this.IllustrationID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.illustrationid = (int)reader[COL_ILLUSTRATIONID];
			this.diagram = (System.Xml.XmlDocument)reader[COL_DIAGRAM];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ILLUSTRATION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Diagram), PARAM_DIAGRAM));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.IllustrationID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ILLUSTRATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Diagram), PARAM_DIAGRAM));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ILLUSTRATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProductModelIllustrations(ProductModelIllustration productModelIllustration)
        {
           productModelIllustration.IllustrationEntity = this;
        }
        
        private void DeAssociateProductModelIllustrations(ProductModelIllustration productModelIllustration)
        {
          if(productModelIllustration.IllustrationEntity == this)
             productModelIllustration.IllustrationEntity = null;
        }
        
        private ProductModelIllustration[] GetChildrenProductModelIllustrations()
        {
            ProductModelIllustration childrenQuery = new ProductModelIllustration();
            childrenQuery.IllustrationEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
