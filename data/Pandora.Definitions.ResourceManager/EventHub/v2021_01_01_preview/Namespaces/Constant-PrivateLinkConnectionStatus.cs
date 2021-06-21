using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum PrivateLinkConnectionStatus
	{
		[Description("Approved")]
		Approved,

		[Description("Disconnected")]
		Disconnected,

		[Description("Pending")]
		Pending,

		[Description("Rejected")]
		Rejected,
	}
}
