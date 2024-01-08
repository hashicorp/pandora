using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingTypeConstant
{
    [Description("Cluster")]
    Cluster,

    [Description("Workspaces")]
    Workspaces,
}
