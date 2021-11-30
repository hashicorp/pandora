using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DeliveryAttributeMappingTypeConstant
    {
        [Description("Dynamic")]
        Dynamic,

        [Description("Static")]
        Static,
    }
}
