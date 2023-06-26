using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterNetworkAccessFlagConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
