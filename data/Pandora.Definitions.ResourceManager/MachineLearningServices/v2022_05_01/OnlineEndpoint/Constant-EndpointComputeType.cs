using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointComputeTypeConstant
{
    [Description("AzureMLCompute")]
    AzureMLCompute,

    [Description("Kubernetes")]
    Kubernetes,

    [Description("Managed")]
    Managed,
}
