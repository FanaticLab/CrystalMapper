/******************************************************************
 * Author: Faraz Masood Khan
 * Description: Helper functions used by templates
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 ******************************************************************/

using System;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Text;

using CodeSmith.Engine;
using SchemaExplorer;

public enum VisualStudioVersion
{
    VS_2005,
    VS_2008
}

public class HelperFunctions : CodeTemplate
{
    private char ParamIdentifier(TableSchema table)
    {
        switch (table.Database.Provider.Name)
        {
            case "OracleSchemaProvider":
            case "SQLiteSchemaProvider":
                return ':';
            case "SqlSchemaProvider":
            case "MySQLSchemaProvider":
            case "PostgreSQLSchemaProvider":
            case "SqlCompactSchemaProvider":
                return '@';
            default:
                throw new InvalidOperationException(string.Format("There is no template exists for schema provider '{0}'", table.Database.Provider.Name));
        }
    }

    private MapCollection _keyWords;
    public MapCollection KeyWords
    {
        get
        {
            if (_keyWords == null)
            {
                string path;
                Map.TryResolvePath("CSharpKeyWordEscape", CodeTemplateInfo.DirectoryName, out path);
                _keyWords = Map.Load(path);
            }
            return _keyWords;
        }
    }
    #region Variable & Class Name Methods

    public string GetPropertyName(TableSchema table, ColumnSchema column)
    {
        if (ColumnHasAlias(column))
            return GetPropertyName(GetNameFromColumn(column));
        else
        {
            string className = GetClassName(table);
            string name = GetPropertyName(className);
            return name == className ? name + "Member" : name;
        }
    }
    public string GetPropertyName(ColumnSchema column)
    {
        string propertyName = GetPropertyName(GetNameFromColumn(column));

        if (propertyName == GetClassName(column.Table))
        {
            if (column.SystemType.IsArray)
                propertyName += StringUtil.ToPlural(StringUtil.ToPascalCase(column.SystemType.Name));
            else
                propertyName += StringUtil.ToPascalCase(column.SystemType.Name);
        }

        if (propertyName.EndsWith("Id"))
            propertyName = propertyName.Substring(0, propertyName.Length - 2) + "ID";

        return propertyName;
    }
    private string GetPropertyName(string name)
    {
        if (!name.Contains("_"))
            name += "_";
        return StringUtil.ToPascalCase(name);
    }

    public string GetPropertyNamePlural(TableSchema table, ColumnSchema column)
    {
        if (ColumnHasAlias(column))
            return GetPropertyNamePlural(GetNameFromColumn(column));
        else
        {
            string className = GetClassName(table);
            string name = GetPropertyNamePlural(className);
            return name == className ? className + "List" : name;
        }
    }
    public string GetPropertyNamePlural(ColumnSchema column)
    {
        return GetPropertyNamePlural(GetNameFromColumn(column));
    }
    private string GetPropertyNamePlural(string name)
    {
        return StringUtil.ToPlural(StringUtil.ToPascalCase(name));
    }

    public string GetPrivateVariableName(TableSchema table, ColumnSchema column)
    {
        if (ColumnHasAlias(column))
            return GetPrivateVariableName(GetNameFromColumn(column));
        else
            return GetPrivateVariableName(GetClassName(table));
    }
    public string GetPrivateVariableName(ColumnSchema column)
    {
        return GetPrivateVariableName(GetNameFromColumn(column));
    }
    private string GetPrivateVariableName(string name)
    {
        return GetVariableName(name);
    }

    public string GetInsertQuery(TableSchema table, string tablePrefix = null)
    {
        string query = "\"INSERT INTO " + GetTableName(table) +" (";
        
        foreach (ColumnSchema column in table.Columns)
        {
            if (!IsIdentityColumn(column))
                query += GetColumnName(column) + ", ";
        }       

        query = query.TrimEnd(new char[] { ',', ' ' }) + ") VALUES (";

        foreach (ColumnSchema column in table.Columns)
        {
            if (!IsIdentityColumn(column) && !IsComputed(column))
                query += " " + GetParamName(column) + ",";
        }

        var identityColumn = GetIdentityColumn(table);
        if (table.Database.Provider.Name == "PostgreSQLSchemaProvider" && identityColumn != null)
            query = query.TrimEnd(',') + ") RETURNING " + GetColumnName(identityColumn) + ";\"";
        else
            query = query.TrimEnd(',') + ");\"";

        return query;
    }

    public string GetUpdateQuery(TableSchema table, string tablePrefix = null)
    {
        string query =   "\"UPDATE " + GetTableName(table) + " SET";

        foreach (ColumnSchema column in table.NonPrimaryKeyColumns)
            if(!IsComputed(column))
                query += GetColumnName(column) + " = " + GetParamName(column) + ", ";

        query = query.TrimEnd(new char[] { ',', ' ' }) + " WHERE ";

        if (table.HasPrimaryKey)
        {
            foreach (ColumnSchema column in table.PrimaryKey.MemberColumns)
                query += GetColumnName(column) + " = " + GetParamName(column) + " AND ";
        }
        else
        {

            foreach (ColumnSchema column in table.Columns)
                query += GetColumnName(column) + " = " + GetParamName(column) + " AND ";
        }
    
        return query.Substring(0, query.Length - 5) + "\"";
    }

    public string GetDeleteQuery(TableSchema table, string tablePrefix = null)
    {
        string query = "\"DELETE FROM " + GetTableName(table) + " WHERE ";

        if (table.HasPrimaryKey)
        {
            foreach (ColumnSchema column in table.PrimaryKey.MemberColumns)
                query += " " + GetColumnName(column) + " = " + GetParamName(column) + " AND";
        }
        else
        {
            foreach (ColumnSchema column in table.Columns)
                query += " " + GetColumnName(column) + " = " + GetParamName(column) + " AND";
        }

        query = query.Substring(0, query.Length - 3) + "\"";      

        return query;
    }

    public ColumnSchema GetIdentityColumn(TableSchema table)
    {
        foreach (ColumnSchema column in table.Columns)
            if (IsIdentityColumn(column))
                return column;

        return null;
    }

    public static bool IsComputed(ColumnSchema column)
    {
        return (column.ExtendedProperties.Contains("CS_IsComputed") && ((bool)column.ExtendedProperties["CS_IsComputed"].Value));
    }

    public string GetPrivateVariableNamePlural(TableSchema table, ColumnSchema column)
    {
        if (ColumnHasAlias(column))
            return GetPrivateVariableNamePlural(GetNameFromColumn(column));
        else
            return GetPrivateVariableNamePlural(GetClassName(table));
    }
    public string GetPrivateVariableNamePlural(ColumnSchema column)
    {
        return GetPrivateVariableNamePlural(GetNameFromColumn(column));
    }
    private string GetPrivateVariableNamePlural(string name)
    {
        return GetVariableNamePlural(name);
    }

    public string GetVariableName(TableSchema table, ColumnSchema column)
    {
        if (ColumnHasAlias(column))
            return GetVariableName(GetNameFromColumn(column));
        else
            return GetVariableName(GetClassName(table));
    }
    public string GetVariableName(ColumnSchema column)
    {
        return GetVariableName(GetNameFromColumn(column));
    }
    private string GetVariableName(string name)
    {
        if (!name.Contains("_"))
            name = name.ToLower();
        return StringUtil.ToSingular(StringUtil.ToCamelCase(name));
    }

    public string GetVariableNamePlural(TableSchema table, ColumnSchema column)
    {
        if (ColumnHasAlias(column))
            return GetVariableNamePlural(GetNameFromColumn(column));
        else
            return GetVariableNamePlural(GetClassName(table));
    }
    public string GetVariableNamePlural(ColumnSchema column)
    {
        return GetVariableNamePlural(GetNameFromColumn(column));
    }
    private string GetVariableNamePlural(string name)
    {
        return StringUtil.ToPlural(StringUtil.ToCamelCase(name));
    }

    public string GetClassName(TableSchema table)
    {
        string className;
        if (table.ExtendedProperties.Contains(extendedPropertyName))
            className = table.ExtendedProperties[extendedPropertyName].Value.ToString();
        else
        {
            className = table.Name;

            if (!String.IsNullOrEmpty(tablePrefix) && className.StartsWith(tablePrefix))
                className = className.Remove(0, tablePrefix.Length);
        }

        return StringUtil.ToSingular(StringUtil.ToPascalCase(className));
    }
    
    public string GetDbClassName(DatabaseSchema database)
    {
        return StringUtil.ToPascalCase(database.Name);
    }

    public string GetClassNamePlural(TableSchema table)
    {
        return StringUtil.ToPlural(GetClassName(table));
    }

    public string GetTableNameWithOutPrefix(TableSchema table)
    {
        string className;
        if (table.ExtendedProperties.Contains(extendedPropertyName))
            className = table.ExtendedProperties[extendedPropertyName].Value.ToString();
        else
        {
            className = table.Name;

            if (!String.IsNullOrEmpty(tablePrefix) && className.StartsWith(tablePrefix))
                className = className.Remove(0, tablePrefix.Length);
        }

        return className;
    }

    protected string tablePrefix = String.Empty;

    private bool ColumnHasAlias(ColumnSchema column)
    {
        return column != null && column.ExtendedProperties.Contains(extendedPropertyName);
    }
    private string GetNameFromColumn(ColumnSchema column)
    {
        return ColumnHasAlias(column) ? column.ExtendedProperties[extendedPropertyName].Value.ToString() : column.Name;
    }
    private const string extendedPropertyName = "cs_alias";

    #endregion

    #region ManyToMany Table Methods
    
    public List<TableKeySchema> GetForeignKeyTables(TableSchema primaryTable)
    {
        var retVal = new List<TableKeySchema>();
        
        foreach(TableSchema foreignTable in primaryTable.Database.Tables)
            foreach(var foreignKey in foreignTable.ForeignKeys)
                if(foreignKey.PrimaryKeyTable.Equals(primaryTable))                    
                    if(!retVal.Any(k => k.Name == foreignKey.Name && k.ForeignKeyTable == foreignKey.ForeignKeyTable))
                        retVal.Add(foreignKey);
        
        return retVal;
    }

    public TableSchema GetToManyTable(TableSchema manyToTable, TableSchema sourceTable)
    {
        TableSchema result = null;
        foreach (TableKeySchema key in manyToTable.ForeignKeys)
            if (!key.PrimaryKeyTable.Equals(sourceTable))
            {
                result = key.PrimaryKeyTable;
                break;
            }
        return result;
    }
    
    public static MemberColumnSchema GetToManyTableKey(TableSchema manyToTable, TableSchema foreignTable)
    {
        MemberColumnSchema result = null;
        foreach (TableKeySchema key in manyToTable.ForeignKeys)
            if (key.PrimaryKeyTable.Equals(foreignTable))
            {
                result = key.ForeignKeyMemberColumns[0];
                break;
            }
        return result;
    }
    
    public bool IsManyToMany(TableSchema table)
    {
        // If there are 2 ForeignKeyColumns AND...
        // ...there are only two columns OR
        //    there are 3 columns and 1 is a primary key.

        if (table.ForeignKeys.Count != 2 || table.ForeignKeys[0].PrimaryKeyTable == table.ForeignKeys[1].PrimaryKeyTable)
            return false;

        foreach (ColumnSchema column in table.NonKeyColumns)
        {
            switch (column.Name.ToLower())
            {
                case "createdon":
                case "createdby":
                case "updatedon":
                case "updatedby":
                    break;
                default:
                    return false;
            }
        }

        return true;
    }

    #endregion

    public string GetCascade(MemberColumnSchema column)
    {
        return column.AllowDBNull ? "all" : "all-delete-orphan";
    }

    #region BusinessObject Methods

    public string GetInitialization(Type type)
    {
        string result;

        if (type.Equals(typeof(String)))
            result = "String.Empty";
        else if (type.Equals(typeof(DateTime)))
            result = "new DateTime()";
        else if (type.Equals(typeof(Decimal)))
            result = "default(decimal)";
        else if (type.Equals(typeof(Guid)))
            result = "Guid.Empty";
        else if (type.IsPrimitive)
            result = String.Format("default({0})", type.Name.ToString());
        else
            result = "null";
        return result;
    }
    public Type GetBusinessBaseIdType(TableSchema table)
    {
        if (IsMutliColumnPrimaryKey(table.PrimaryKey))
            return typeof(string);
        else
            return GetPrimaryKeyColumn(table.PrimaryKey).SystemType;
    }

    #endregion

    #region PrimaryKey Methods

    public MemberColumnSchema GetPrimaryKeyColumn(PrimaryKeySchema primaryKey)
    {
        if (primaryKey.MemberColumns.Count != 1)
            throw new System.ApplicationException("This method will only work on primary keys with exactly one member column.");
        return primaryKey.MemberColumns[0];
    }
    public bool IsMutliColumnPrimaryKey(PrimaryKeySchema primaryKey)
    {
        if (primaryKey.MemberColumns.Count == 0)
            throw new System.ApplicationException("This template will only work on primary keys with exactly one member column.");

        return (primaryKey.MemberColumns.Count > 1);
    }
    public string GetForeignKeyColumnClassName(MemberColumnSchema mcs, TableSchema table)
    {
        string result = String.Empty;
        foreach (TableKeySchema tks in table.ForeignKeys)
            if (tks.ForeignKeyMemberColumns.Contains(mcs))
            {
                result = GetPropertyName(tks.PrimaryKeyTable.Name);
                break;
            }
        return result;
    }

    #endregion

    #region Method Creation Methods

    public string GetMethodParameters(List<MemberColumnSchema> mcsList, bool isDeclaration)
    {
        StringBuilder result = new StringBuilder();
        bool isFirst = true;
        foreach (MemberColumnSchema mcs in mcsList)
        {
            if (isFirst)
                isFirst = false;
            else
                result.Append(", ");
            if (isDeclaration)
            {
                result.Append(mcs.SystemType.ToString());
                result.Append(" ");
            }
            result.Append(KeyWords[GetVariableName(mcs)]);
        }
        return result.ToString();
    }
    public string GetMethodParameters(MemberColumnSchemaCollection mcsc, bool isDeclaration)
    {
        List<MemberColumnSchema> mcsList = new List<MemberColumnSchema>();
        for (int x = 0; x < mcsc.Count; x++)
            mcsList.Add(mcsc[x]);
        return GetMethodParameters(mcsList, isDeclaration);
    }
    public string GetMethodDeclaration(SearchCriteria sc)
    {
        StringBuilder result = new StringBuilder();
        result.Append(sc.MethodName);
        result.Append("(");
        result.Append(GetMethodParameters(sc.Items, true));
        result.Append(")");
        return result.ToString();
    }
    public string GetPrimaryKeyCallParameters(List<MemberColumnSchema> mcsList)
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();
        for (int x = 0; x < mcsList.Count; x++)
        {
            if (x > 0)
                result.Append(", ");

            if (mcsList[x].SystemType == typeof(Guid))
                result.AppendFormat("new {0}(keys[{1}])", mcsList[x].SystemType, x);
            else if (mcsList[x].SystemType == typeof(string))
                result.AppendFormat("keys[{0}]", x);
            else
                result.AppendFormat("{0}.Parse(keys[{1}])", mcsList[x].SystemType, x);
        }
        return result.ToString();
    }

    #endregion

    public TableSchema GetForeignTable(MemberColumnSchema mcs, TableSchema table)
    {
        foreach (TableKeySchema tks in table.ForeignKeys)
            if (tks.ForeignKeyMemberColumns.Contains(mcs))
                return tks.PrimaryKeyTable;
        throw new Exception(String.Format("Could not find Column {0} in Table {1}'s ForeignKeys.", mcs.Name, table.Name));
    }

    protected Random random = new Random();
    public string GetUnitTestInitialization(ColumnSchema column)
    {
        string result;

        if (column.SystemType.Equals(typeof(String)))
        {
            StringBuilder sb = new StringBuilder();

            int size = (column.Size > 0 && column.Size < 100) ? random.Next(1, column.Size) : 10;

            sb.Append("\"");
            for (int x = 0; x < size; x++)
            {
                switch (x % 5)
                {
                    case 0:
                        sb.Append("T");
                        break;
                    case 1:
                        sb.Append("e");
                        break;
                    case 2:
                        sb.Append("s");
                        break;
                    case 3:
                        sb.Append("t");
                        break;
                    case 4:
                        sb.Append(" ");
                        break;
                }
            }
            sb.Append("\"");

            result = sb.ToString();
        }
        else if (column.SystemType.Equals(typeof(DateTime)))
            result = "DateTime.Now";
        else if (column.SystemType.Equals(typeof(Decimal)))
            result = Convert.ToDecimal(random.Next(1, 100)).ToString();
        else if (column.SystemType.Equals(typeof(Int32)))
            result = random.Next(1, 100).ToString();
        else if (column.SystemType.Equals(typeof(Boolean)))
            result = (random.Next(1, 2).Equals(1)).ToString().ToLower();
        else if (column.SystemType.Equals(typeof(Guid)))
            result = "Guid.Empty";
        else if (column.SystemType.IsPrimitive)
            result = String.Format("default({0})", column.SystemType.Name.ToString());
        else
            result = "null";

        return result;
    }

    public bool ContainsForeignKey(SearchCriteria sc, TableSchemaCollection tsc)
    {
        foreach (TableSchema ts in tsc)
            foreach (TableKeySchema tks in ts.PrimaryKeys)
                foreach (MemberColumnSchema mcs in sc.Items)
                    if (tks.PrimaryKeyMemberColumns.Contains(mcs))
                        return true;
        return false;
    }

    public bool IsIdentityColumnExists(TableSchema table)
    {
        foreach (ColumnSchema column in table.Columns)
            if (IsIdentityColumn(column))
                return true;

        return false;
    }

    public bool IsIdentityColumn(ColumnSchema column)
    {
        if (column.Database.Provider.Name == "PostgreSQLSchemaProvider"
           && column.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase)
           && column.Table.PrimaryKey != null)
            foreach (MemberColumnSchema primaryKey in column.Table.PrimaryKey.MemberColumns)
                if (primaryKey.Name == column.Name)
                    return true;


        foreach (ExtendedProperty extentedProp in column.ExtendedProperties)
            if (extentedProp.Name == "CS_IsIdentity" && true.Equals(extentedProp.Value))
                return true;

        return false;
    }

    public string GetChiledIdentifiedName(TableSchema sourceTable, TableSchema toManyTable, TableKeySchema tableKey)
    {
        int relationCount = 0;

        foreach (TableKeySchema key in toManyTable.ForeignKeys)
            if (key.PrimaryKeyTable.Equals(sourceTable))
                relationCount++;

        if (relationCount > 1)
            return GetPropertyName(tableKey.ForeignKeyMemberColumns[0]) + GetClassNamePlural(tableKey.ForeignKeyTable);

        return GetClassNamePlural(tableKey.ForeignKeyTable);
    }

    public string GetColumnName(ColumnSchema column)
    {
        return column.Name; // Quote(column.Database.Provider, column.Name);
    }

    public string GetParamName(ColumnSchema column)
    {
        return ParamIdentifier(column.Table) + column.Name.Replace(' ', '_');
    }

    public string GetConstantColumnName(ColumnSchema column)
    {
        return "COL_" + column.Name.ToUpper().Replace(' ', '_');
    }

    public string GetConstantParamName(ColumnSchema column)
    {
        return "PARAM_" + column.Name.ToUpper().Replace(' ', '_');
    }
    
    public string GetTableName(TableSchema table, string tablePrefix = null)
    {
        if (tablePrefix != null)
            return tablePrefix + Quote(table.Database.Provider, table.Name);

        return string.Join(".", table.FullName.Split('.').Select(n => Quote(table.Database.Provider, n)).ToArray());
        //return Quote(table.Database.Provider, table.Database.Provider.Name == "PostgreSQLSchemaProvider" ? table.Name : table.FullName);
    }
    
    public string Quote(IDbSchemaProvider provider, string name)
    {        
        switch(provider.Name)
        {
            case "MySQLSchemaProvider":
                return "`" + name + "`";
            case "SQLiteSchemaProvider" :
            case "PostgreSQLSchemaProvider":
                return "\"" + name + "\"";
            default:
            case "SqlSchemaProvider" :
            case "SqlCompactSchemaProvider" :
                return "[" + name + "]";
        }
    }

    public string GetPropertyDeclaration(ColumnSchema column, string csharpDataType)
    {
        string propDeclaration = string.Empty;
        if (!column.AllowDBNull && column.SystemType.IsPrimitive)
        {
            propDeclaration = @"[Column(@ConstantColumn, @ConstantParam, default(@DataType))]
        public virtual @DataType @PropertyName ";
        }
        else if (!column.AllowDBNull && column.SystemType.IsValueType)
        {
            propDeclaration = @"[Column(@ConstantColumn, @ConstantParam, typeof(@DataType))]
        public virtual @DataType @PropertyName ";
        }
        else if (column.AllowDBNull && column.SystemType.IsValueType)
        {
            propDeclaration = @"[Column(@ConstantColumn, @ConstantParam )]
        public virtual @DataType? @PropertyName ";
        }
        else
        {
            propDeclaration = @"[Column(@ConstantColumn, @ConstantParam )]
        public virtual @DataType @PropertyName ";
        }

        return propDeclaration.Replace("@ConstantColumn", GetConstantColumnName(column))
                              .Replace("@ConstantParam", GetConstantParamName(column))
                              .Replace("@DataType", csharpDataType)
                              .Replace("@PropertyName", GetPropertyName(column));
    }

    public string GetCollectionVariableName(TableSchema table)
    {
        return StringUtil.ToCamelCase(StringUtil.ToPlural(GetClassName(table)));
    }

    public string GetCollectionPropertyName(TableSchema table)
    {
        return StringUtil.ToPascalCase(StringUtil.ToPlural(GetClassName(table)));
    }

    public string GetUniqueCollectionPropName(TableSchema table, TableKeySchema keySchema)
    {
        int count = 0;
        foreach (TableKeySchema tks in table.ForeignKeys)
            if (tks.PrimaryKeyTable.Equals(keySchema.PrimaryKeyTable))
                count++;

        // fix of StringUtil bug     
        string collectionPropName = StringUtil.ToPascalCase(StringUtil.ToPlural(StringUtil.ToPascalCase((count > 1 ? (GetClassName(table) + TrimId(GetPropertyName(keySchema.ForeignKeyMemberColumns[0]))) : GetClassName(table)))));
        if (collectionPropName.ToLower() == "address")
            collectionPropName += "es";

        return collectionPropName;
    }

    public string GetUniqueCollectionVarName(TableSchema table, TableKeySchema keySchema)
    {
        int count = 0;
        foreach (TableKeySchema tks in table.ForeignKeys)
            if (tks.PrimaryKeyTable.Equals(keySchema.PrimaryKeyTable))
                count++;

        // fix of StringUtil bug    
        string collectionVarName = StringUtil.ToPlural(StringUtil.ToCamelCase((count > 1 ? (GetClassName(table) + TrimId(GetPropertyName(keySchema.ForeignKeyMemberColumns[0]))) : GetClassName(table))));
        if (collectionVarName.ToLower() == "address")
            collectionVarName += "es";

        return collectionVarName;
    }

    public string GetClassVariableName(TableSchema table)
    {
        return StringUtil.ToCamelCase(GetClassName(table));
    }

    public string GetForeignKeyClassVarName(TableKeySchema key)
    {
        string suffix = "Ref";

        foreach (TableKeySchema k in key.ForeignKeyTable.ForeignKeys)
            if (!k.Equals(key) && k.PrimaryKeyTable.Equals(key.PrimaryKeyTable) && key.ForeignKeyMemberColumns[0].Column != null)
                return TrimEnd(GetPrivateVariableName(key.ForeignKeyMemberColumns[0].Column), "id", "code") + suffix;

        if (key.PrimaryKeyTable.Equals(key.ForeignKeyTable) && key.ForeignKeyMemberColumns.Count == 1 && key.ForeignKeyMemberColumns[0].Column != null)
            return TrimEnd(GetPrivateVariableName(key.ForeignKeyMemberColumns[0].Column), "id", "code") + suffix;

        return StringUtil.ToCamelCase(GetClassName(key.PrimaryKeyTable)) + suffix;
    }

    public string GetForeignKeyClassPropName(TableKeySchema key)
    {
        string suffix = "Ref";

        foreach (TableKeySchema k in key.ForeignKeyTable.ForeignKeys)
            if (!k.Equals(key) && k.PrimaryKeyTable.Equals(key.PrimaryKeyTable))
                return TrimEnd(GetPropertyName(key.ForeignKeyMemberColumns[0].Column), "id", "code") + suffix;

        if (key.PrimaryKeyTable.Equals(key.ForeignKeyTable) && key.ForeignKeyMemberColumns.Count == 1)
            return TrimEnd(GetPropertyName(key.ForeignKeyMemberColumns[0].Column), "id", "code") + suffix;

        return GetClassName(key.PrimaryKeyTable) + suffix;
    }

    public string TrimEnd(string value, params string[] args)
    {
        if (args != null)
            foreach (string arg in args)
                if (value != null && value.Length > 0 && value.ToLower().EndsWith(arg.ToLower()))
                    return value.Substring(0, value.Length - arg.Length);

        return value;
    }

    public string TrimId(string name)
    {
        if (name != null && name.Length > 2 && name.ToLower().EndsWith("id"))
            return name.Substring(0, name.Length - 2);

        return name;
    }
}

#region SearchCriteria Class

public class SearchCriteria
{
    #region Static Content

    public static List<SearchCriteria> GetAllSearchCriteria(TableSchema table, string extendedProperty)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table, extendedProperty);
        return tsc.GetAllSearchCriteria();
    }
    public static List<SearchCriteria> GetAllSearchCriteria(TableSchema table)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table);
        return tsc.GetAllSearchCriteria();
    }

    public static List<SearchCriteria> GetPrimaryKeySearchCriteria(TableSchema table, string extendedProperty)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table, extendedProperty);
        return tsc.GetPrimaryKeySearchCriteria();
    }
    public static List<SearchCriteria> GetPrimaryKeySearchCriteria(TableSchema table)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table);
        return tsc.GetPrimaryKeySearchCriteria();
    }

    public static List<SearchCriteria> GetForeignKeySearchCriteria(TableSchema table, string extendedProperty)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table, extendedProperty);
        return tsc.GetForeignKeySearchCriteria();
    }
    public static List<SearchCriteria> GetForeignKeySearchCriteria(TableSchema table)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table);
        return tsc.GetForeignKeySearchCriteria();
    }

    public static List<SearchCriteria> GetIndexSearchCriteria(TableSchema table, string extendedProperty)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table, extendedProperty);
        return tsc.GetIndexSearchCriteria();
    }
    public static List<SearchCriteria> GetIndexSearchCriteria(TableSchema table)
    {
        TableSearchCriteria tsc = new TableSearchCriteria(table);
        return tsc.GetIndexSearchCriteria();
    }

    #endregion

    #region Declarations

    protected List<MemberColumnSchema> mcsList;
    protected MethodNameGenerationMode methodNameGenerationMode = MethodNameGenerationMode.Default;
    protected string methodName = String.Empty;
    protected string extendedProperty;
    protected bool isPrimaryKey;

    #endregion

    #region Constructors

    protected SearchCriteria(string extendedProperty)
        : this(extendedProperty, new List<MemberColumnSchema>(), false)
    {


    }
    protected SearchCriteria(string extendedProperty, List<MemberColumnSchema> mcsList)
        : this(extendedProperty, mcsList, false)
    {
    }
    protected SearchCriteria(string extendedProperty, List<MemberColumnSchema> mcsList, bool isPrimaryKey)
    {
        this.extendedProperty = extendedProperty;
        this.mcsList = mcsList;
        this.isPrimaryKey = isPrimaryKey;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets MethodName to default generation: "GetBy{0}{1}{n}"
    /// </summary>
    public void SetMethodNameGeneration()
    {
        methodNameGenerationMode = MethodNameGenerationMode.Default;

        GenerateMethodName("GetBy", String.Empty, String.Empty);
    }
    /// <summary>
    /// Sets MethodName to be value of the specified Extended Property from the database.
    /// </summary>
    /// <param name="extendedProperty">Value of the Extended Property.</param>
    public void SetMethodNameGeneration(string extendedProperty)
    {
        methodNameGenerationMode = MethodNameGenerationMode.ExtendedProperty;

        methodName = extendedProperty;
    }
    /// <summary>
    /// Sets MethodName to custom generation: "{prefix}{0}{delimeter}{1}{suffix}"
    /// </summary>
    /// <param name="prefix">Method Prefix</param>
    /// <param name="delimeter">Column Delimeter</param>
    /// <param name="suffix">Method Suffix</param>
    public void SetMethodNameGeneration(string prefix, string delimeter, string suffix)
    {
        methodNameGenerationMode = MethodNameGenerationMode.Custom;

        GenerateMethodName(prefix, delimeter, suffix);
    }

    public override string ToString()
    {
        if (String.IsNullOrEmpty(methodName))
            SetMethodNameGeneration();

        return methodName;
    }

    protected void Add(MemberColumnSchema item)
    {
        mcsList.Add(item);
    }
    protected void GenerateMethodName(string prefix, string delimeter, string suffix)
    {
        StringBuilder sb = new StringBuilder();
        bool isFirst = true;

        sb.Append(prefix);
        foreach (MemberColumnSchema mcs in mcsList)
        {
            if (isFirst)
                isFirst = false;
            else
                sb.Append(delimeter);

            if (mcs.ExtendedProperties.Contains(extendedProperty))
                sb.Append(mcs.ExtendedProperties[extendedProperty].Value.ToString());
            else
                sb.Append(mcs.Name);
        }
        sb.Append(suffix);

        methodName = sb.ToString();
    }

    #endregion

    #region Properties

    public bool IsAllUnique
    {
        get
        {
            bool result = false;
            foreach (MemberColumnSchema msc in mcsList)
                if (msc.IsUnique)
                {
                    result = true;
                    break;
                }
            return result;
        }
    }
    public List<MemberColumnSchema> Items
    {
        get { return mcsList; }
    }
    public bool IsPrimaryKey
    {
        get { return isPrimaryKey; }
    }
    public string MethodName
    {
        get { return this.ToString(); }
    }
    public MethodNameGenerationMode MethodNameGeneration
    {
        get { return methodNameGenerationMode; }
    }

    protected string Key
    {
        get
        {
            StringBuilder sb = new StringBuilder();

            foreach (MemberColumnSchema mcs in mcsList)
                sb.Append(mcs.Name);

            return sb.ToString();
        }
    }

    #endregion

    #region Enums & Classes

    public enum MethodNameGenerationMode
    {
        Default,
        ExtendedProperty,
        Custom
    }

    internal class TableSearchCriteria
    {
        #region Declarations

        protected TableSchema table;
        protected string extendedProperty = String.Empty;
        protected const string defaultExtendedProperty = "cs_alias";

        #endregion

        #region Constructor

        public TableSearchCriteria(TableSchema sourceTable)
        {
            this.table = sourceTable;
        }
        public TableSearchCriteria(TableSchema sourceTable, string extendedProperty)
            : this(sourceTable)
        {
            this.extendedProperty = extendedProperty;
        }

        #endregion

        #region Methods

        public List<SearchCriteria> GetAllSearchCriteria()
        {
            Dictionary<string, SearchCriteria> map = new Dictionary<string, SearchCriteria>();

            GetPrimaryKeySearchCriteria(map);
            GetForeignKeySearchCriteria(map);
            GetIndexSearchCriteria(map);

            return GetResultsFromMap(map);
        }
        public List<SearchCriteria> GetPrimaryKeySearchCriteria()
        {
            Dictionary<string, SearchCriteria> map = new Dictionary<string, SearchCriteria>();

            GetPrimaryKeySearchCriteria(map);

            return GetResultsFromMap(map);
        }
        public List<SearchCriteria> GetForeignKeySearchCriteria()
        {
            Dictionary<string, SearchCriteria> map = new Dictionary<string, SearchCriteria>();

            GetForeignKeySearchCriteria(map);

            return GetResultsFromMap(map);
        }
        public List<SearchCriteria> GetIndexSearchCriteria()
        {
            Dictionary<string, SearchCriteria> map = new Dictionary<string, SearchCriteria>();

            GetIndexSearchCriteria(map);

            return GetResultsFromMap(map);
        }

        protected void GetPrimaryKeySearchCriteria(Dictionary<string, SearchCriteria> map)
        {
            List<MemberColumnSchema> mcsList = new List<MemberColumnSchema>(table.PrimaryKey.MemberColumns.ToArray());
            SearchCriteria searchCriteria = new SearchCriteria(ExtendedProperty, mcsList, true);

            if (!String.IsNullOrEmpty(ExtendedProperty)
               && table.PrimaryKey.ExtendedProperties.Contains(ExtendedProperty)
               && table.PrimaryKey.ExtendedProperties[ExtendedProperty].Value != null
              )
                searchCriteria.SetMethodNameGeneration(table.PrimaryKey.ExtendedProperties[ExtendedProperty].Value.ToString());

            AddToMap(map, searchCriteria);
        }
        protected void GetForeignKeySearchCriteria(Dictionary<string, SearchCriteria> map)
        {
            foreach (TableKeySchema tks in table.ForeignKeys)
            {
                SearchCriteria searchCriteria = new SearchCriteria(ExtendedProperty);
                foreach (MemberColumnSchema mcs in tks.ForeignKeyMemberColumns)
                    if (mcs.Table.Equals(table))
                        searchCriteria.Add(mcs);

                if (!String.IsNullOrEmpty(ExtendedProperty) && tks.ExtendedProperties.Contains(ExtendedProperty) && tks.ExtendedProperties[ExtendedProperty].Value != null)
                    searchCriteria.SetMethodNameGeneration(tks.ExtendedProperties[ExtendedProperty].Value.ToString());

                AddToMap(map, searchCriteria);
            }
        }
        protected void GetIndexSearchCriteria(Dictionary<string, SearchCriteria> map)
        {
            foreach (IndexSchema indexSchema in table.Indexes)
            {
                SearchCriteria searchCriteria = new SearchCriteria(ExtendedProperty);
                foreach (MemberColumnSchema mcs in indexSchema.MemberColumns)
                    if (mcs.Table.Equals(table))
                        searchCriteria.Add(mcs);

                if (!String.IsNullOrEmpty(ExtendedProperty) && indexSchema.ExtendedProperties.Contains(ExtendedProperty) && indexSchema.ExtendedProperties[ExtendedProperty].Value != null)
                    searchCriteria.SetMethodNameGeneration(indexSchema.ExtendedProperties[ExtendedProperty].Value.ToString());

                AddToMap(map, searchCriteria);
            }
        }

        protected bool AddToMap(Dictionary<string, SearchCriteria> map, SearchCriteria searchCriteria)
        {
            string key = searchCriteria.Key;
            bool result = (searchCriteria.Items.Count > 0 && !map.ContainsKey(key));

            if (result)
                map.Add(key, searchCriteria);

            return result;
        }
        protected List<SearchCriteria> GetResultsFromMap(Dictionary<string, SearchCriteria> map)
        {
            List<SearchCriteria> result = new List<SearchCriteria>();
            foreach (SearchCriteria sc in map.Values)
                result.Add(sc);
            return result;
        }

        #endregion

        #region Properties

        public string ExtendedProperty
        {
            get { return (String.IsNullOrEmpty(extendedProperty)) ? defaultExtendedProperty : extendedProperty; }
        }
        public TableSchema Table
        {
            get { return table; }
        }

        #endregion
    }

    #endregion
}

#endregion
