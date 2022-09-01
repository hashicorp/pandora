using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupScheduleTypeConstant
{
    [Description("Automated")]
    Automated,

    [Description("Manual")]
    Manual,
}
