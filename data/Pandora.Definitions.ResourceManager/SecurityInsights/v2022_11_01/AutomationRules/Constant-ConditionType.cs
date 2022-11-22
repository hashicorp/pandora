using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionTypeConstant
{
    [Description("Property")]
    Property,

    [Description("PropertyArrayChanged")]
    PropertyArrayChanged,

    [Description("PropertyChanged")]
    PropertyChanged,
}
