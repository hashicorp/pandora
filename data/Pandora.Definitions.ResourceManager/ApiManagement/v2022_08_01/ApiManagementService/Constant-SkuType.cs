using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiManagementService;

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
