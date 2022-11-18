using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoftwareAssuranceStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
