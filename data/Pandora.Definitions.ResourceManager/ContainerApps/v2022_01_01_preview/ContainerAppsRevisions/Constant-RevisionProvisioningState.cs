using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RevisionProvisioningStateConstant
{
    [Description("Deprovisioned")]
    Deprovisioned,

    [Description("Deprovisioning")]
    Deprovisioning,

    [Description("Failed")]
    Failed,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,
}
