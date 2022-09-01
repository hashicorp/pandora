using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncodingCaptureDescriptionConstant
{
    [Description("Avro")]
    Avro,

    [Description("AvroDeflate")]
    AvroDeflate,
}
