using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PersistentVolumeRestoreModeConstant
{
    [Description("RestoreWithVolumeData")]
    RestoreWithVolumeData,

    [Description("RestoreWithoutVolumeData")]
    RestoreWithoutVolumeData,
}
