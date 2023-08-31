using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BareMetalMachineKeySetPrivilegeLevelConstant
{
    [Description("Standard")]
    Standard,

    [Description("Superuser")]
    Superuser,
}
