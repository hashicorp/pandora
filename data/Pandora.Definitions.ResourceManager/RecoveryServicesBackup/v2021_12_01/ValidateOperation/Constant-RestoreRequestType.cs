using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ValidateOperation;

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
