using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigServerStateConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("NotAvailable")]
    NotAvailable,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
