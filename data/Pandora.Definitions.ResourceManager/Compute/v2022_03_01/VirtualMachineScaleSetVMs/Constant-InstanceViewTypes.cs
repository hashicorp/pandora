using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSetVMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstanceViewTypesConstant
{
    [Description("instanceView")]
    InstanceView,

    [Description("userData")]
    UserData,
}
