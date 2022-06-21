using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncTypeConstant
{
    [Description("Default")]
    Default,

    [Description("ForceResync")]
    ForceResync,
}
