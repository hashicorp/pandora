using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal enum IdentityType
	{
		[Description("None")]
		None,

		[Description("SystemAssigned")]
		SystemAssigned,

		[Description("SystemAssigned, UserAssigned")]
		SystemAssignedUserAssigned,

		[Description("UserAssigned")]
		UserAssigned,
	}
}
