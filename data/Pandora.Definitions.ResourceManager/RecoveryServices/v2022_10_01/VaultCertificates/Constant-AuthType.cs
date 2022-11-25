using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_10_01.VaultCertificates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthTypeConstant
{
    [Description("AAD")]
    AAD,

    [Description("ACS")]
    ACS,

    [Description("AccessControlService")]
    AccessControlService,

    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("Invalid")]
    Invalid,
}
