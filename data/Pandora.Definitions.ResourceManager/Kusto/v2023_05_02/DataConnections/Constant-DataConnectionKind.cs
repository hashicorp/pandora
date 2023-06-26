using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectionKindConstant
{
    [Description("CosmosDb")]
    CosmosDb,

    [Description("EventGrid")]
    EventGrid,

    [Description("EventHub")]
    EventHub,

    [Description("IotHub")]
    IotHub,
}
