using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.ClusterPrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalAssignmentTypeConstant
{
    [Description("Microsoft.Kusto/clusters/principalAssignments")]
    MicrosoftPointKustoClustersPrincipalAssignments,
}
