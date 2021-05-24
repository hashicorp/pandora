using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum EncodingCaptureDescription
	{
		[Description("Avro")]
		Avro,

		[Description("AvroDeflate")]
		AvroDeflate,
	}
}
