using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorTypeConstant
{
    [Description("Contains")]
    Contains,

    [Description("In")]
    In,
}
