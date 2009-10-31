/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Illustration
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
    public partial class Illustration : Entity<Illustration>
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

        private const string SQL_INSERT_ILLUSTRATION = "INSERT INTO Production.Illustration([Diagram],[ModifiedDate]) VALUES (@Diagram,@ModifiedDate);";

        private const string SQL_UPDATE_ILLUSTRATION = "UPDATE Production.Illustration SET [Diagram] = @Diagram, [ModifiedDate] = @ModifiedDate,  WHERE [IllustrationID] = @IllustrationID";

        private const string SQL_DELETE_ILLUSTRATION = "DELETE FROM Production.Illustration WHERE  [IllustrationID] = @IllustrationID ";

        #endregion
        #region Properties

        [Column(COL_ILLUSTRATIONID, PARAM_ILLUSTRATIONID, default(int))]
        public virtual int IllustrationID { get; set; }


        [Column(COL_DIAGRAM, PARAM_DIAGRAM)]
        public virtual string Diagram { get; set; }

        [Column(COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
        public virtual System.DateTime ModifiedDate { get; set; }

        public IEnumerable<ProductModelIllustration> ProductModelIllustrations
        {
            get
            {
                foreach (ProductModelIllustration productModelIllustration in ProductModelIllustrationList())
                    yield return productModelIllustration;
            }
        }


        public IEnumerable<ProductModel> ProductModels
        {
            get
            {

                foreach (ProductModel productModel in ProductModelList())
                    yield return productModel;
            }
        }


        #endregion


        #region Methods

        public override void Read(DbDataReader reader)
        {
            this.IllustrationID = (int)reader[COL_ILLUSTRATIONID];
            this.Diagram = (string)reader[COL_DIAGRAM];
            this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
        }

        public override bool Create(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_INSERT_ILLUSTRATION))
            {
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Diagram), PARAM_DIAGRAM));
                command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if (command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.IllustrationID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;
            }
        }

        public override bool Update(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_UPDATE_ILLUSTRATION))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Diagram), PARAM_DIAGRAM));
                command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));

                return (command.ExecuteNonQuery() == 1);
            }
        }

        public override bool Delete(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_DELETE_ILLUSTRATION))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion

        #region Children

        public ProductModelIllustration GetProductModelIllustrationsQuery()
        {
            return new ProductModelIllustration
            {
                IllustrationID = this.IllustrationID
            };
        }

        public ProductModelIllustration[] ProductModelIllustrationList()
        {
            return GetProductModelIllustrationsQuery().ToList();
        }



        public ProductModel[] ProductModelList()
        {
            string sqlQuery = @"SELECT Production.ProductModel.*
                                FROM Production.ProductModelIllustration
                                INNER JOIN Production.ProductModel ON                                                                            
                                Production.ProductModelIllustration.[ProductModelID] = Production.ProductModel.[ProductModelID] AND
                                Production.ProductModelIllustration.[IllustrationID] = @IllustrationID  
                                ";

            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_ILLUSTRATIONID, this.IllustrationID);

            return ProductModel.ToList(sqlQuery, parameterValues);

        }

        #endregion
    }
}
