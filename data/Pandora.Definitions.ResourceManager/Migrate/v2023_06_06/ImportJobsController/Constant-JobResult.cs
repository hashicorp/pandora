using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportJobsController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobResultConstant
{
    [Description("Completed")]
    Completed,

    [Description("CompletedWithErrors")]
    CompletedWithErrors,

    [Description("CompletedWithWarnings")]
    CompletedWithWarnings,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Unknown")]
    Unknown,

    [Description("WaitingForBlobUpload")]
    WaitingForBlobUpload,
}
