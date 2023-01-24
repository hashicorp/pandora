using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.ServiceResource;

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
