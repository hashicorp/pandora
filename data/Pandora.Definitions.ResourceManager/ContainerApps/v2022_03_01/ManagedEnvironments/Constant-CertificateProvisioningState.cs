using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ManagedEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("DeleteFailed")]
    DeleteFailed,

    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,
}
