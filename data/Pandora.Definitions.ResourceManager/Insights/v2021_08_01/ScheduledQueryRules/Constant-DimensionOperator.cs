using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DimensionOperatorConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,
}
