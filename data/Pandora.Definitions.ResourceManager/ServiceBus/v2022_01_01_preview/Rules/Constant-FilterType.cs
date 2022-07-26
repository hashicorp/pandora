using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.Rules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FilterTypeConstant
{
    [Description("CorrelationFilter")]
    CorrelationFilter,

    [Description("SqlFilter")]
    SqlFilter,
}
