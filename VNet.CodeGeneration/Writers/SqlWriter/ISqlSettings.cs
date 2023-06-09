namespace VNet.Scientific.CodeGen.Writers.SqlWriter
{
    public interface ISqlSettings
    {
        string GetIndent(int indentLevel);
        string GetTableName(string tableName);
        string GetColumnName(string columnName, string columnType);
        string BatchSeparator { get; }
    }
}