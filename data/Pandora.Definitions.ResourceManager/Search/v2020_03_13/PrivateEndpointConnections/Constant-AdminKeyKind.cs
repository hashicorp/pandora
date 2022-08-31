using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.PrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdminKeyKindConstant
{
    [Description("primary")]
    Primary,

    [Description("secondary")]
    Secondary,
}
