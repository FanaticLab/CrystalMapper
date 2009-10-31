/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: SpecialOffer
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
    public partial class SpecialOffer : Entity< SpecialOffer>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SpecialOffer";	
     
		public const string COL_SPECIALOFFERID = "SpecialOfferID";
		public const string COL_DESCRIPTION = "Description";
		public const string COL_DISCOUNTPCT = "DiscountPct";
		public const string COL_TYPE = "Type";
		public const string COL_CATEGORY = "Category";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_MINQTY = "MinQty";
		public const string COL_MAXQTY = "MaxQty";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SPECIALOFFERID = "@SpecialOfferID";	
        public const string PARAM_DESCRIPTION = "@Description";	
        public const string PARAM_DISCOUNTPCT = "@DiscountPct";	
        public const string PARAM_TYPE = "@Type";	
        public const string PARAM_CATEGORY = "@Category";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_MINQTY = "@MinQty";	
        public const string PARAM_MAXQTY = "@MaxQty";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SPECIALOFFER = "INSERT INTO Sales.SpecialOffer([Description],[DiscountPct],[Type],[Category],[StartDate],[EndDate],[MinQty],[MaxQty],[rowguid],[ModifiedDate]) VALUES (@Description,@DiscountPct,@Type,@Category,@StartDate,@EndDate,@MinQty,@MaxQty,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SPECIALOFFER = "UPDATE Sales.SpecialOffer SET [Description] = @Description, [DiscountPct] = @DiscountPct, [Type] = @Type, [Category] = @Category, [StartDate] = @StartDate, [EndDate] = @EndDate, [MinQty] = @MinQty, [MaxQty] = @MaxQty, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SpecialOfferID] = @SpecialOfferID";
		
		private const string SQL_DELETE_SPECIALOFFER = "DELETE FROM Sales.SpecialOffer WHERE  [SpecialOfferID] = @SpecialOfferID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SPECIALOFFERID, PARAM_SPECIALOFFERID, default(int))]
                              public virtual int SpecialOfferID  { get; set; }		
		
        
	    [Column( COL_DESCRIPTION, PARAM_DESCRIPTION )]
                              public virtual string Description  { get; set; }	      
        
	    [Column( COL_DISCOUNTPCT, PARAM_DISCOUNTPCT, typeof(decimal))]
                              public virtual decimal DiscountPct  { get; set; }	      
        
	    [Column( COL_TYPE, PARAM_TYPE )]
                              public virtual string Type  { get; set; }	      
        
	    [Column( COL_CATEGORY, PARAM_CATEGORY )]
                              public virtual string Category  { get; set; }	      
        
	    [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate  { get; set; }	      
        
	    [Column( COL_ENDDATE, PARAM_ENDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime EndDate  { get; set; }	      
        
	    [Column( COL_MINQTY, PARAM_MINQTY, default(int))]
                              public virtual int MinQty  { get; set; }	      
        
	    [Column( COL_MAXQTY, PARAM_MAXQTY )]
                              public virtual int? MaxQty  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< SpecialOfferProduct> SpecialOfferProducts
        {
            get {
                  foreach(SpecialOfferProduct specialOfferProduct in SpecialOfferProductList())
                    yield return specialOfferProduct; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SpecialOfferID = (int)reader[COL_SPECIALOFFERID];
			this.Description = (string)reader[COL_DESCRIPTION];
			this.DiscountPct = (decimal)reader[COL_DISCOUNTPCT];
			this.Type = (string)reader[COL_TYPE];
			this.Category = (string)reader[COL_CATEGORY];
			this.StartDate = (System.DateTime)reader[COL_STARTDATE];
			this.EndDate = (System.DateTime)reader[COL_ENDDATE];
			this.MinQty = (int)reader[COL_MINQTY];
			this.MaxQty = DbConvert.ToNullable< int >(reader[COL_MAXQTY]);
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SPECIALOFFER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.DiscountPct, PARAM_DISCOUNTPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.Type, PARAM_TYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Category, PARAM_CATEGORY));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndDate, PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinQty, PARAM_MINQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.MaxQty), PARAM_MAXQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.SpecialOfferID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SPECIALOFFER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.DiscountPct, PARAM_DISCOUNTPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.Type, PARAM_TYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Category, PARAM_CATEGORY));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndDate, PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinQty, PARAM_MINQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.MaxQty), PARAM_MAXQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SPECIALOFFER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public SpecialOfferProduct GetSpecialOfferProductsQuery()
        {
            return new SpecialOfferProduct {                
                                                                            SpecialOfferID = this.SpecialOfferID  
                                                                            };
        }
        
        public SpecialOfferProduct[] SpecialOfferProductList()
        {
            return GetSpecialOfferProductsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
