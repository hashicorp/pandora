using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceProviderConnectionConstant
{
    [Description("Inbound")]
    Inbound,

    [Description("Outbound")]
    Outbound,
}
