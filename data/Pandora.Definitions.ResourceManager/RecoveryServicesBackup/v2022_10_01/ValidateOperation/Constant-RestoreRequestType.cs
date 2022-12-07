using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.ValidateOperation;

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
