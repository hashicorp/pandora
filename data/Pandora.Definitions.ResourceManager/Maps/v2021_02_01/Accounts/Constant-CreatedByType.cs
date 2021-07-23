using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
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
