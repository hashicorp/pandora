using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.CustomIPPrefixes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommissionedStateConstant
{
    [Description("Commissioned")]
    Commissioned,

    [Description("Commissioning")]
    Commissioning,

    [Description("Decommissioning")]
    Decommissioning,

    [Description("Deprovisioning")]
    Deprovisioning,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,
}
