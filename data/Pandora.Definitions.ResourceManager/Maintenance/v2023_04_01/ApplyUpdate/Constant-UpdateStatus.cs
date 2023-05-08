using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01.ApplyUpdate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateStatusConstant
{
    [Description("Completed")]
    Completed,

    [Description("InProgress")]
    InProgress,

    [Description("Pending")]
    Pending,

    [Description("RetryLater")]
    RetryLater,

    [Description("RetryNow")]
    RetryNow,
}
