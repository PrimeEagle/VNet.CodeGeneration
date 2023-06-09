namespace VNet.Scientific.CodeGen.Writers.SqlWriter
{
    public class SqlServerSqlSettings : ISqlSettings
    {
        public string GetIndent(int indentLevel)
        {
            return new string('\t', indentLevel);
        }

        public string GetTableName(string tableName)
        {
            return $"CREATE TABLE [{tableName}]";
        }

        public string GetColumnName(string columnName, string columnType)
        {
            return $"[{columnName}] {columnType}";
        }

        public string BatchSeparator => "GO";
    }
}