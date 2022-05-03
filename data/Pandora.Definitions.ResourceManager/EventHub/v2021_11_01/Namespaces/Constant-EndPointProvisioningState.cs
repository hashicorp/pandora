using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndPointProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
