using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.RouteFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
