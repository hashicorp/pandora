using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2022_09_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateLinkServiceConnectionProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Incomplete")]
    Incomplete,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
