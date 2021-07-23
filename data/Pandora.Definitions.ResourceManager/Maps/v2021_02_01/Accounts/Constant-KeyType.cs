using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum KeyType
	{
		[Description("primary")]
		Primary,

		[Description("secondary")]
		Secondary,
	}
}
