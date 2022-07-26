using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharedPrivateLinkResourceProvisioningStateConstant
{
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
