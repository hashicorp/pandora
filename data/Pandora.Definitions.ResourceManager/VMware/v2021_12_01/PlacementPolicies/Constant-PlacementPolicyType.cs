using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.PlacementPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlacementPolicyTypeConstant
{
    [Description("VmHost")]
    VMHost,

    [Description("VmVm")]
    VMVM,
}
