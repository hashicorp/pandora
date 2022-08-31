using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.SchemaRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SchemaTypeConstant
{
    [Description("Avro")]
    Avro,

    [Description("Unknown")]
    Unknown,
}
