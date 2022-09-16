using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectionKindConstant
{
    [Description("EventGrid")]
    EventGrid,

    [Description("EventHub")]
    EventHub,

    [Description("IotHub")]
    IotHub,
}
