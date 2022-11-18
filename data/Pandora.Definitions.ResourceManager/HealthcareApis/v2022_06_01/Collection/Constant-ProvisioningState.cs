using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_06_01.Collection;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Deprovisioned")]
    Deprovisioned,

    [Description("Failed")]
    Failed,

    [Description("Moving")]
    Moving,

    [Description("Succeeded")]
    Succeeded,

    [Description("Suspended")]
    Suspended,

    [Description("SystemMaintenance")]
    SystemMaintenance,

    [Description("Updating")]
    Updating,

    [Description("Verifying")]
    Verifying,

    [Description("Warned")]
    Warned,
}
