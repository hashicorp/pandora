using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ServerConfigurationOptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Created")]
    Created,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,
}
