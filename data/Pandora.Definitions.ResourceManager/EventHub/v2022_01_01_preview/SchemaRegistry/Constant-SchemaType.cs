using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.SchemaRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SchemaTypeConstant
{
    [Description("Avro")]
    Avro,

    [Description("Unknown")]
    Unknown,
}
