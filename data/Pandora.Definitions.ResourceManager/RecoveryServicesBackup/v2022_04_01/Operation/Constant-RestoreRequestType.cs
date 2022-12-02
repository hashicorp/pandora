using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.Operation;

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
