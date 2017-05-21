﻿namespace NDomain.Sql
{
    public class SqlObjectNames
    {
        public static readonly SqlObjectNames Default =
            new SqlObjectNames("ndomain", "Aggregates", "Events");

        public SqlObjectNames(string schemaName, string aggregateTableName, string eventTableName)
        {
            SchemaName = schemaName;
            AggregateTableName = aggregateTableName;
            EventTableName = eventTableName;
        }

        public string SchemaName { get; }
        public string AggregateTableName { get; }
        public string EventTableName { get; }
    }
}
