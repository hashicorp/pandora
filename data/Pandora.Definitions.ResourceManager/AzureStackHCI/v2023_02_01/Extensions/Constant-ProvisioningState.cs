using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.Extensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

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

    [Description("Provisioning")]
    Provisioning,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
