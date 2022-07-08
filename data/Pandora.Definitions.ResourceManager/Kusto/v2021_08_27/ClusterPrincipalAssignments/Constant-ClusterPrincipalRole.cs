using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.ClusterPrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterPrincipalRoleConstant
{
    [Description("AllDatabasesAdmin")]
    AllDatabasesAdmin,

    [Description("AllDatabasesViewer")]
    AllDatabasesViewer,
}
