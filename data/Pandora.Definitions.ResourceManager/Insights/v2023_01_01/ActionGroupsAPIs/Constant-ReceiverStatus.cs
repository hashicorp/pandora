using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2023_01_01.ActionGroupsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReceiverStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("NotSpecified")]
    NotSpecified,
}
