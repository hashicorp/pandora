using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.PrivateEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicIPAddressSkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Standard")]
    Standard,
}
