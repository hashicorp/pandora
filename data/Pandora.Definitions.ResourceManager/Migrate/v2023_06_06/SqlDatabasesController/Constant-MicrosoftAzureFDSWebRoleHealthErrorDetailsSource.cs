using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlDatabasesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MicrosoftAzureFDSWebRoleHealthErrorDetailsSourceConstant
{
    [Description("RefreshFabricLayout")]
    RefreshFabricLayout,

    [Description("RefreshFabricLayoutDependencyMap")]
    RefreshFabricLayoutDependencyMap,

    [Description("RefreshFabricLayoutGuest")]
    RefreshFabricLayoutGuest,
}
