using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryConstant
{
    [Description("Cost")]
    Cost,

    [Description("HighAvailability")]
    HighAvailability,

    [Description("OperationalExcellence")]
    OperationalExcellence,

    [Description("Performance")]
    Performance,

    [Description("Security")]
    Security,
}
