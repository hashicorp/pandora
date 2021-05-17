using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal enum ConnectionStatus
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
