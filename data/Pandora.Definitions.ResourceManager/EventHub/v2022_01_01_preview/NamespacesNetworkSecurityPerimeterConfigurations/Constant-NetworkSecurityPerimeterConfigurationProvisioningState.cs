using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.NamespacesNetworkSecurityPerimeterConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkSecurityPerimeterConfigurationProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("InvalidResponse")]
    InvalidResponse,

    [Description("Succeeded")]
    Succeeded,

    [Description("SucceededWithIssues")]
    SucceededWithIssues,

    [Description("Unknown")]
    Unknown,

    [Description("Updating")]
    Updating,
}
