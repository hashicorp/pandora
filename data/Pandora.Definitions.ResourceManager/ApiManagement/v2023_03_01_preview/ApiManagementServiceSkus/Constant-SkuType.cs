using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiManagementServiceSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuTypeConstant
{
    [Description("Basic")]
    Basic,

    [Description("Consumption")]
    Consumption,

    [Description("Developer")]
    Developer,

    [Description("Isolated")]
    Isolated,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
