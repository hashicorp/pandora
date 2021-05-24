using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{
	[ConstantType(ConstantTypeAttribute.ConstantType.String)]
	internal enum IdentityType
	{
		[Description("SystemAssigned")]
		SystemAssigned,
	}
}
