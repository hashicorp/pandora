using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Recommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NotificationLevelConstant
{
    [Description("Critical")]
    Critical,

    [Description("Information")]
    Information,

    [Description("NonUrgentSuggestion")]
    NonUrgentSuggestion,

    [Description("Warning")]
    Warning,
}
