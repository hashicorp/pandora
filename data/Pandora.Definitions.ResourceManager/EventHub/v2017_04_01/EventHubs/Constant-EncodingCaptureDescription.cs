using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum EncodingCaptureDescriptionConstant
    {
        [Description("Avro")]
        Avro,

        [Description("AvroDeflate")]
        AvroDeflate,
    }
}
