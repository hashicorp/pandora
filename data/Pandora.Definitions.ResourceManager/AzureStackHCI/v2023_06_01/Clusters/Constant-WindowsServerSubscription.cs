using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsServerSubscriptionConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
