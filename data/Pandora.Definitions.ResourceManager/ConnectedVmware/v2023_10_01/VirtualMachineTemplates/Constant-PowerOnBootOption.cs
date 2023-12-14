using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PowerOnBootOptionConstant
{
    [Description("disabled")]
    Disabled,

    [Description("enabled")]
    Enabled,
}
