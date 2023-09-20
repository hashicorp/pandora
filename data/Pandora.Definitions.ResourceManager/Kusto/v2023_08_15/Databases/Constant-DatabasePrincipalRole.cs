using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.Databases;

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
