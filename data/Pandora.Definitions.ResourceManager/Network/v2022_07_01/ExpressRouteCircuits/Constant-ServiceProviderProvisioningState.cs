using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCircuits;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceProviderProvisioningStateConstant
{
    [Description("Deprovisioning")]
    Deprovisioning,

    [Description("NotProvisioned")]
    NotProvisioned,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,
}
