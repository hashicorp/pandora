using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeDetailedStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Error")]
    Error,

    [Description("Provisioning")]
    Provisioning,
}
