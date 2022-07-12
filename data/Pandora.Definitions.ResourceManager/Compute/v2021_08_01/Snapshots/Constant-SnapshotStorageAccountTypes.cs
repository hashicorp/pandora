using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SnapshotStorageAccountTypesConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("Standard_ZRS")]
    StandardZRS,
}
