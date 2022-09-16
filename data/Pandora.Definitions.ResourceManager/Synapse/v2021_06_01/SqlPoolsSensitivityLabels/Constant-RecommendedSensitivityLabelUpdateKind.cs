using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsSensitivityLabels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedSensitivityLabelUpdateKindConstant
{
    [Description("disable")]
    Disable,

    [Description("enable")]
    Enable,
}
