using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTypeConstant
{
    [Description("Cassandra")]
    Cassandra,

    [Description("Gremlin")]
    Gremlin,

    [Description("GremlinV2")]
    GremlinVTwo,

    [Description("MongoDB")]
    MongoDB,

    [Description("Sql")]
    Sql,

    [Description("Table")]
    Table,
}
