using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.SchemaRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SchemaTypeConstant
{
    [Description("Avro")]
    Avro,

    [Description("Unknown")]
    Unknown,
}
