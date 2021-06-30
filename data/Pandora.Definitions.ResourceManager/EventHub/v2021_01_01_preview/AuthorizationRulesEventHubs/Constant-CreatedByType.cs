using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesEventHubs
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum CreatedByType
	{
		[Description("Application")]
		Application,

		[Description("Key")]
		Key,

		[Description("ManagedIdentity")]
		ManagedIdentity,

		[Description("User")]
		User,
	}
}
