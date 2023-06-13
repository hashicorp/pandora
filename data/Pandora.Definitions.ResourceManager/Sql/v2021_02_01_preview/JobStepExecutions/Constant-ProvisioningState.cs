using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.JobStepExecutions;

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
