using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.DatabasePrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabasePrincipalAssignmentTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/principalAssignments")]
    MicrosoftPointKustoClustersDatabasesPrincipalAssignments,
}
