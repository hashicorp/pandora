using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunStatusConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Error")]
    Error,

    [Description("Failed")]
    Failed,

    [Description("Queued")]
    Queued,

    [Description("Running")]
    Running,

    [Description("Started")]
    Started,

    [Description("Succeeded")]
    Succeeded,

    [Description("Timeout")]
    Timeout,
}
