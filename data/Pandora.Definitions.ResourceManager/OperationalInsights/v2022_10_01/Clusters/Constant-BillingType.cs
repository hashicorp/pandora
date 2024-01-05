using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingTypeConstant
{
    [Description("Cluster")]
    Cluster,

    [Description("Workspaces")]
    Workspaces,
}
