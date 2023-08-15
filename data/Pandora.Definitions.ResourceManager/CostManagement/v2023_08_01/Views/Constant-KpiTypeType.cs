using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KpiTypeTypeConstant
{
    [Description("Budget")]
    Budget,

    [Description("Forecast")]
    Forecast,
}
