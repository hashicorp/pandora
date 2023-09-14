using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.TomcatWebApplicationsController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthErrorDetailsDiscoveryScopeConstant
{
    [Description("AppsAndRoles")]
    AppsAndRoles,

    [Description("DependencyMap")]
    DependencyMap,

    [Description("DiscoveryTargets")]
    DiscoveryTargets,

    [Description("SQLServerConnectionInfo")]
    SQLServerConnectionInfo,

    [Description("StaticData")]
    StaticData,
}
