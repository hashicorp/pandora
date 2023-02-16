using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsServerSubscriptionConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
