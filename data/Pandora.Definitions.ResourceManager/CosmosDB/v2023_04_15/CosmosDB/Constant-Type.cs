using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("Cassandra")]
    Cassandra,

    [Description("CassandraConnectorMetadata")]
    CassandraConnectorMetadata,

    [Description("Gremlin")]
    Gremlin,

    [Description("GremlinV2")]
    GremlinVTwo,

    [Description("MongoDB")]
    MongoDB,

    [Description("Sql")]
    Sql,

    [Description("SqlDedicatedGateway")]
    SqlDedicatedGateway,

    [Description("Table")]
    Table,

    [Description("Undefined")]
    Undefined,
}
