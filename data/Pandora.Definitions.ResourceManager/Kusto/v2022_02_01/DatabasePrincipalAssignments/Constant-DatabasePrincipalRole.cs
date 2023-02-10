using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.DatabasePrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabasePrincipalRoleConstant
{
    [Description("Admin")]
    Admin,

    [Description("Ingestor")]
    Ingestor,

    [Description("Monitor")]
    Monitor,

    [Description("UnrestrictedViewer")]
    UnrestrictedViewer,

    [Description("User")]
    User,

    [Description("Viewer")]
    Viewer,
}
