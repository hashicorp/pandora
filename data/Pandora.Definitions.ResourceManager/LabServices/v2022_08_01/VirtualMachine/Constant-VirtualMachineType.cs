using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.VirtualMachine;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachineTypeConstant
{
    [Description("Template")]
    Template,

    [Description("User")]
    User,
}
