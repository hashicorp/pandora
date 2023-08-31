using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BareMetalMachineDetailedStatusConstant
{
    [Description("Available")]
    Available,

    [Description("Deprovisioning")]
    Deprovisioning,

    [Description("Error")]
    Error,

    [Description("Preparing")]
    Preparing,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,
}
