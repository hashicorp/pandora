using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.CrossRegionRestore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RestoreRequestTypeConstant
{
    [Description("FullShareRestore")]
    FullShareRestore,

    [Description("Invalid")]
    Invalid,

    [Description("ItemLevelRestore")]
    ItemLevelRestore,
}
