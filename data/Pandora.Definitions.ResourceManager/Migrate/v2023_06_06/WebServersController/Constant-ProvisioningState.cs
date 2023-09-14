using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebServersController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Completed")]
    Completed,

    [Description("Created")]
    Created,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updated")]
    Updated,
}
