using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum PublicNetworkAccess
	{
		[Description("Disabled")]
		Disabled,

		[Description("Enabled")]
		Enabled,
	}
}
