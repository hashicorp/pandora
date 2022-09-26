using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingNamesConstant
{
    [Description("AutoLogon")]
    AutoLogon,

    [Description("FirstLogonCommands")]
    FirstLogonCommands,
}
