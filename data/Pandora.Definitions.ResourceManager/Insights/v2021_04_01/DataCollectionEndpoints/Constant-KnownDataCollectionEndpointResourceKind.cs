using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownDataCollectionEndpointResourceKindConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
