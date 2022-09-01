using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.SharedPrivateLinkResources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdminKeyKindConstant
{
    [Description("primary")]
    Primary,

    [Description("secondary")]
    Secondary,
}
