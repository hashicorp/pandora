using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeliveryAttributeMappingTypeConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
