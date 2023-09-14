using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlSitesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlSitePropertiesDiscoveryScenarioConstant
{
    [Description("DR")]
    DR,

    [Description("Migrate")]
    Migrate,
}
