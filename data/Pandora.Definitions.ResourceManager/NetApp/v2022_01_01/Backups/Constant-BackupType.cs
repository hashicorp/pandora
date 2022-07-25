using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_01_01.Backups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupTypeConstant
{
    [Description("Manual")]
    Manual,

    [Description("Scheduled")]
    Scheduled,
}
