using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.TaskResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TaskStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("FailedInputValidation")]
    FailedInputValidation,

    [Description("Faulted")]
    Faulted,

    [Description("Queued")]
    Queued,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,
}
