using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.Extensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeExtensionStateConstant
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

    [Description("Moving")]
    Moving,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
