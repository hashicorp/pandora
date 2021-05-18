using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateEndpointConnections
{
	internal enum ProvisioningState
	{
		[Description("Canceled")]
		Canceled,

		[Description("Creating")]
		Creating,

		[Description("Deleting")]
		Deleting,

		[Description("Failed")]
		Failed,

		[Description("Succeeded")]
		Succeeded,

		[Description("Updating")]
		Updating,
	}
}
