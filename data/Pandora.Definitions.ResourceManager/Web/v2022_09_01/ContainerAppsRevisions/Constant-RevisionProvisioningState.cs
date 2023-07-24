using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ContainerAppsRevisions;

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
