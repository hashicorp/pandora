using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataResidencyBoundaryConstant
{
    [Description("WithinGeopair")]
    WithinGeopair,

    [Description("WithinRegion")]
    WithinRegion,
}
