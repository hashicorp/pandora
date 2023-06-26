using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.ClusterPrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalAssignmentTypeConstant
{
    [Description("Microsoft.Kusto/clusters/principalAssignments")]
    MicrosoftPointKustoClustersPrincipalAssignments,
}
