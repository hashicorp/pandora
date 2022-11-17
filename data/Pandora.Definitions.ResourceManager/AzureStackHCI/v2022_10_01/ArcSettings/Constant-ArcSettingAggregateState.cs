using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.ArcSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArcSettingAggregateStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Connected")]
    Connected,

    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Disconnected")]
    Disconnected,

    [Description("Error")]
    Error,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Moving")]
    Moving,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("PartiallyConnected")]
    PartiallyConnected,

    [Description("PartiallySucceeded")]
    PartiallySucceeded,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
