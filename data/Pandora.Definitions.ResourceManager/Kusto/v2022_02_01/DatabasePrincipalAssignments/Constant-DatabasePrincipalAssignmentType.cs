using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.DatabasePrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabasePrincipalAssignmentTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/principalAssignments")]
    MicrosoftPointKustoClustersDatabasesPrincipalAssignments,
}
