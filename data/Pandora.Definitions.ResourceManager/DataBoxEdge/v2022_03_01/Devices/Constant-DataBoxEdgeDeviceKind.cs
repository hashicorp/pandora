using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataBoxEdgeDeviceKindConstant
{
    [Description("AzureDataBoxGateway")]
    AzureDataBoxGateway,

    [Description("AzureModularDataCentre")]
    AzureModularDataCentre,

    [Description("AzureStackEdge")]
    AzureStackEdge,

    [Description("AzureStackHub")]
    AzureStackHub,
}
