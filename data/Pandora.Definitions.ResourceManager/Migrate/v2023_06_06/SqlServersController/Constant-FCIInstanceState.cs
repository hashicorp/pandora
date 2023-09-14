using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FCIInstanceStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Inherited")]
    Inherited,

    [Description("Initializing")]
    Initializing,

    [Description("Offline")]
    Offline,

    [Description("OfflinePending")]
    OfflinePending,

    [Description("Online")]
    Online,

    [Description("OnlinePending")]
    OnlinePending,

    [Description("Pending")]
    Pending,

    [Description("Unknown")]
    Unknown,
}
