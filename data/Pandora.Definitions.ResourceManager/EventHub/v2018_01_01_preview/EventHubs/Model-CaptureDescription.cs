using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs
{

	internal class CaptureDescription
	{
		[JsonPropertyName("destination")]
		public Destination? Destination { get; set; }

		[JsonPropertyName("enabled")]
		public bool Enabled { get; set; }

		[JsonPropertyName("encoding")]
		public EncodingCaptureDescription Encoding { get; set; }

		[JsonPropertyName("intervalInSeconds")]
		public int IntervalInSeconds { get; set; }

		[JsonPropertyName("sizeLimitInBytes")]
		public int SizeLimitInBytes { get; set; }

		[JsonPropertyName("skipEmptyArchives")]
		public bool SkipEmptyArchives { get; set; }
	}
}
