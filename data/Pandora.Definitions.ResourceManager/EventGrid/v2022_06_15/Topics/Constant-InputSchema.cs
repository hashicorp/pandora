using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Topics;

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
