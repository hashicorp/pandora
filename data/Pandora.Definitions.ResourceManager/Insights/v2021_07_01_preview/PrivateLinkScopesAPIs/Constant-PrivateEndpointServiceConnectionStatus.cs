using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_07_01_preview.PrivateLinkScopesAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateEndpointServiceConnectionStatusConstant
{
    [Description("Approved")]
    Approved,

    [Description("Pending")]
    Pending,

    [Description("Rejected")]
    Rejected,
}
