using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Domains
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum InputSchemaConstant
    {
        [Description("CloudEventSchemaV1_0")]
        CloudEventSchemaVOneZero,

        [Description("CustomEventSchema")]
        CustomEventSchema,

        [Description("EventGridSchema")]
        EventGridSchema,
    }
}
