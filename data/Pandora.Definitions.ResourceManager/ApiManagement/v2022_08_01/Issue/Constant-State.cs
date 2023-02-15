using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Issue;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateConstant
{
    [Description("closed")]
    Closed,

    [Description("open")]
    Open,

    [Description("proposed")]
    Proposed,

    [Description("removed")]
    Removed,

    [Description("resolved")]
    Resolved,
}
