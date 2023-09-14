using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervSitesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiscoveryScopesConstant
{
    [Description("AppsAndRoles")]
    AppsAndRoles,

    [Description("DependencyMap")]
    DependencyMap,

    [Description("SQLServerConnectionInfo")]
    SQLServerConnectionInfo,

    [Description("StaticData")]
    StaticData,
}
