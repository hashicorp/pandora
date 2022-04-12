using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RevisionHealthStateConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("None")]
    None,

    [Description("Unhealthy")]
    Unhealthy,
}
