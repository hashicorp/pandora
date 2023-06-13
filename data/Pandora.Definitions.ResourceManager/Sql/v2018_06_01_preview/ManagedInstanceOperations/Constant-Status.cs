using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstanceOperations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("NotStarted")]
    NotStarted,

    [Description("SlowedDown")]
    SlowedDown,
}
