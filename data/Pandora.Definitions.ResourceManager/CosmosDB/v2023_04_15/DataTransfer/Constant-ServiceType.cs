using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.DataTransfer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceTypeConstant
{
    [Description("DataTransfer")]
    DataTransfer,

    [Description("GraphAPICompute")]
    GraphAPICompute,

    [Description("MaterializedViewsBuilder")]
    MaterializedViewsBuilder,

    [Description("SqlDedicatedGateway")]
    SqlDedicatedGateway,
}
