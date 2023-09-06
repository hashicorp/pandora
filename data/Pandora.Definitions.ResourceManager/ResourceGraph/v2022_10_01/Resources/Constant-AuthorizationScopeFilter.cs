using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ResourceGraph.v2022_10_01.Resources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthorizationScopeFilterConstant
{
    [Description("AtScopeAboveAndBelow")]
    AtScopeAboveAndBelow,

    [Description("AtScopeAndAbove")]
    AtScopeAndAbove,

    [Description("AtScopeAndBelow")]
    AtScopeAndBelow,

    [Description("AtScopeExact")]
    AtScopeExact,
}
