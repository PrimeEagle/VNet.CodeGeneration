namespace VNet.CodeGeneration.Writers.SqlWriter
{
    public class AnsiSqlSettings : ISqlSettings
    {
        public string GetIndent(int indentLevel)
        {
            return new string(' ', indentLevel * 4);
        }

        public string GetTableName(string tableName)
        {
            return $"CREATE TABLE {tableName}";
        }

        public string GetColumnName(string columnName, string columnType)
        {
            return $"{columnName} {columnType}";
        }

        public string BatchSeparator => "GO";
    }
}