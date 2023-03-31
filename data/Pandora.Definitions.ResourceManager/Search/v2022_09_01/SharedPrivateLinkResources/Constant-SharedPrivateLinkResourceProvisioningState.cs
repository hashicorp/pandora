using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2022_09_01.SharedPrivateLinkResources;

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
