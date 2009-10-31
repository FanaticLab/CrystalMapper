/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 1:15 AM
 * 
 * Class: address
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
    public partial class address : Entity<address>
    {
        #region Table Schema

        public const string TABLE_NAME = "Person.Address";

        public const string COL_ADDRESSID = "AddressID";
        public const string COL_ADDRESSLINE1 = "AddressLine1";
        public const string COL_ADDRESSLINE2 = "AddressLine2";
        public const string COL_CITY = "City";
        public const string COL_STATEPROVINCEID = "StateProvinceID";
        public const string COL_POSTALCODE = "PostalCode";
        public const string COL_ROWGUID = "rowguid";
        public const string COL_MODIFIEDDATE = "ModifiedDate";

        public const string PARAM_ADDRESSID = "@AddressID";
        public const string PARAM_ADDRESSLINE1 = "@AddressLine1";
        public const string PARAM_ADDRESSLINE2 = "@AddressLine2";
        public const string PARAM_CITY = "@City";
        public const string PARAM_STATEPROVINCEID = "@StateProvinceID";
        public const string PARAM_POSTALCODE = "@PostalCode";
        public const string PARAM_ROWGUID = "@rowguid";
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";

        #endregion

        #region Queries

        private const string SQL_INSERT_ADDRESS = "INSERT INTO Person.Address([AddressLine1],[AddressLine2],[City],[StateProvinceID],[PostalCode],[rowguid],[ModifiedDate]) VALUES (@AddressLine1,@AddressLine2,@City,@StateProvinceID,@PostalCode,@rowguid,@ModifiedDate);" + "SELECT @@IDENTITY;";

        private const string SQL_UPDATE_ADDRESS = "UPDATE Person.Address SET [AddressLine1] = @AddressLine1, [AddressLine2] = @AddressLine2, [City] = @City, [StateProvinceID] = @StateProvinceID, [PostalCode] = @PostalCode, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [AddressID] = @AddressID";

        private const string SQL_DELETE_ADDRESS = "DELETE FROM Person.Address WHERE  [AddressID] = @AddressID ";

        #endregion

        #region Properties

        [Column(COL_ADDRESSID, PARAM_ADDRESSID, default(int))]
        public virtual int AddressID { get; set; }


        [Column(COL_ADDRESSLINE1, PARAM_ADDRESSLINE1)]
        public virtual string AddressLine1 { get; set; }

        [Column(COL_ADDRESSLINE2, PARAM_ADDRESSLINE2)]
        public virtual string AddressLine2 { get; set; }

        [Column(COL_CITY, PARAM_CITY)]
        public virtual string City { get; set; }

        [Column(COL_STATEPROVINCEID, PARAM_STATEPROVINCEID, default(int))]
        public virtual int StateProvinceID { get; set; }

        [Column(COL_POSTALCODE, PARAM_POSTALCODE)]
        public virtual string PostalCode { get; set; }

        [Column(COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
        public virtual System.Guid Rowguid { get; set; }

        [Column(COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
        public virtual System.DateTime ModifiedDate { get; set; }

        public IEnumerable<EmployeeAddress> EmployeeAddresses
        {
            get
            {
                foreach (EmployeeAddress employeeAddress in EmployeeAddressList())
                    yield return employeeAddress;
            }
        }

        public IEnumerable<VendorAddress> VendorAddresses
        {
            get
            {
                foreach (VendorAddress vendorAddress in VendorAddressList())
                    yield return vendorAddress;
            }
        }

        public IEnumerable<CustomerAddress> CustomerAddresses
        {
            get
            {
                foreach (CustomerAddress customerAddress in CustomerAddressList())
                    yield return customerAddress;
            }
        }

        public IEnumerable<SalesOrderHeader> BillToAddressIDSalesOrderHeaders
        {
            get
            {
                foreach (SalesOrderHeader salesOrderHeader in BillToAddressIDSalesOrderHeaderList())
                    yield return salesOrderHeader;
            }
        }

        public IEnumerable<SalesOrderHeader> ShipToAddressIDSalesOrderHeaders
        {
            get
            {
                foreach (SalesOrderHeader salesOrderHeader in ShipToAddressIDSalesOrderHeaderList())
                    yield return salesOrderHeader;
            }
        }

        #endregion

        #region Methods

        public override void Read(DbDataReader reader)
        {
            this.AddressID = (int)reader[COL_ADDRESSID];
            this.AddressLine1 = (string)reader[COL_ADDRESSLINE1];
            this.AddressLine2 = DbConvert.ToString(reader[COL_ADDRESSLINE2]);
            this.City = (string)reader[COL_CITY];
            this.StateProvinceID = (int)reader[COL_STATEPROVINCEID];
            this.PostalCode = (string)reader[COL_POSTALCODE];
            this.Rowguid = (System.Guid)reader[COL_ROWGUID];
            this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
        }

        public override bool Create(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_INSERT_ADDRESS))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.AddressLine1, PARAM_ADDRESSLINE1));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AddressLine2), PARAM_ADDRESSLINE2));
                command.Parameters.Add(dataContext.CreateParameter(this.City, PARAM_CITY));
                command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
                command.Parameters.Add(dataContext.CreateParameter(this.PostalCode, PARAM_POSTALCODE));
                command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
                command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.AddressID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
        }

        public override bool Update(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_UPDATE_ADDRESS))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
                command.Parameters.Add(dataContext.CreateParameter(this.AddressLine1, PARAM_ADDRESSLINE1));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AddressLine2), PARAM_ADDRESSLINE2));
                command.Parameters.Add(dataContext.CreateParameter(this.City, PARAM_CITY));
                command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
                command.Parameters.Add(dataContext.CreateParameter(this.PostalCode, PARAM_POSTALCODE));
                command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
                command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));

                return (command.ExecuteNonQuery() == 1);
            }
        }

        public override bool Delete(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_DELETE_ADDRESS))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion

        #region Children

        public EmployeeAddress GetEmployeeAddressesQuery()
        {
            return new EmployeeAddress
            {
                AddressID = this.AddressID
            };
        }

        public EmployeeAddress[] EmployeeAddressList()
        {
            return GetEmployeeAddressesQuery().ToList();
        }

        public VendorAddress GetVendorAddressesQuery()
        {
            return new VendorAddress
            {
                AddressID = this.AddressID
            };
        }

        public VendorAddress[] VendorAddressList()
        {
            return GetVendorAddressesQuery().ToList();
        }

        public CustomerAddress GetCustomerAddressesQuery()
        {
            return new CustomerAddress
            {
                AddressID = this.AddressID
            };
        }

        public CustomerAddress[] CustomerAddressList()
        {
            return GetCustomerAddressesQuery().ToList();
        }

        public SalesOrderHeader GetBillToAddressIDSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader
            {
                BillToAddressID = this.AddressID
            };
        }

        public SalesOrderHeader[] BillToAddressIDSalesOrderHeaderList()
        {
            return GetBillToAddressIDSalesOrderHeadersQuery().ToList();
        }

        public SalesOrderHeader GetShipToAddressIDSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader
            {
                ShipToAddressID = this.AddressID
            };
        }

        public SalesOrderHeader[] ShipToAddressIDSalesOrderHeaderList()
        {
            return GetShipToAddressIDSalesOrderHeadersQuery().ToList();
        }




        #endregion
    }
}
