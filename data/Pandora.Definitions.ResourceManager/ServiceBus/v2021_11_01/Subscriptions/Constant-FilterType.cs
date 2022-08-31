using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FilterTypeConstant
{
    [Description("CorrelationFilter")]
    CorrelationFilter,

    [Description("SqlFilter")]
    SqlFilter,
}
