using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesNamespaces
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum KeyType
	{
		[Description("PrimaryKey")]
		PrimaryKey,

		[Description("SecondaryKey")]
		SecondaryKey,
	}
}
