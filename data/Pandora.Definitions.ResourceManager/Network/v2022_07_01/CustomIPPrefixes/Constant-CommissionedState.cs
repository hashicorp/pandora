using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.CustomIPPrefixes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommissionedStateConstant
{
    [Description("Commissioned")]
    Commissioned,

    [Description("CommissionedNoInternetAdvertise")]
    CommissionedNoInternetAdvertise,

    [Description("Commissioning")]
    Commissioning,

    [Description("Decommissioning")]
    Decommissioning,

    [Description("Deprovisioned")]
    Deprovisioned,

    [Description("Deprovisioning")]
    Deprovisioning,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,
}
