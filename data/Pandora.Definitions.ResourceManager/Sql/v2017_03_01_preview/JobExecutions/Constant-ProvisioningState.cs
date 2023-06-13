using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.JobExecutions;

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
