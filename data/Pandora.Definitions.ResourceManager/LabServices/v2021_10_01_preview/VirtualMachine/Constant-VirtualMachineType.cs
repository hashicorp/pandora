using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachineTypeConstant
{
    [Description("Template")]
    Template,

    [Description("User")]
    User,
}
