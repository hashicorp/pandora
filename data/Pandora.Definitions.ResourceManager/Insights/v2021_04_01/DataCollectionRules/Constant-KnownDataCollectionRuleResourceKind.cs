using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownDataCollectionRuleResourceKindConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
