using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionTypeConstant
{
    [Description("Boolean")]
    Boolean,

    [Description("Property")]
    Property,

    [Description("PropertyArray")]
    PropertyArray,

    [Description("PropertyArrayChanged")]
    PropertyArrayChanged,

    [Description("PropertyChanged")]
    PropertyChanged,
}
