using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebAppSitesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebAppSitePropertiesDiscoveryScenarioConstant
{
    [Description("DR")]
    DR,

    [Description("Migrate")]
    Migrate,
}
