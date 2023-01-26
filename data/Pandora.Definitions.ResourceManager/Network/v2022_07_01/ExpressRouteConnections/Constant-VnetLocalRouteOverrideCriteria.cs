using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VnetLocalRouteOverrideCriteriaConstant
{
    [Description("Contains")]
    Contains,

    [Description("Equal")]
    Equal,
}
