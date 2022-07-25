using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.EventHubs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncodingCaptureDescriptionConstant
{
    [Description("Avro")]
    Avro,

    [Description("AvroDeflate")]
    AvroDeflate,
}
