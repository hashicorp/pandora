using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PlacementPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlacementPolicyTypeConstant
{
    [Description("VmHost")]
    VmHost,

    [Description("VmVm")]
    VmVm,
}
