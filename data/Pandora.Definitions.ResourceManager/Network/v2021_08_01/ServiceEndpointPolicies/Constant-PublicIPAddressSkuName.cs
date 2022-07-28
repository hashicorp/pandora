using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ServiceEndpointPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicIPAddressSkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Standard")]
    Standard,
}
