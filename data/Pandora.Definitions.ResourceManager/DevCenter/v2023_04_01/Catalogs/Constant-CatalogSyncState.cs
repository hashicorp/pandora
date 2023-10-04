using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Catalogs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CatalogSyncStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,
}
