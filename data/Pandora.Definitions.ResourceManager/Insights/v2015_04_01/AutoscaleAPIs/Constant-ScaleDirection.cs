using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.AutoscaleAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleDirectionConstant
{
    [Description("Decrease")]
    Decrease,

    [Description("Increase")]
    Increase,

    [Description("None")]
    None,
}
