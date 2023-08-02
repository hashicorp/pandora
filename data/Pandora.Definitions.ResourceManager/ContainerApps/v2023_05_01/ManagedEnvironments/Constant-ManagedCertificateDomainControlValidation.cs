using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ManagedEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedCertificateDomainControlValidationConstant
{
    [Description("CNAME")]
    CNAME,

    [Description("HTTP")]
    HTTP,

    [Description("TXT")]
    TXT,
}
