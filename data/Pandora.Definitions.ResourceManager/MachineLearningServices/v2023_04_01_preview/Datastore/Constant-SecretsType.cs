using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Datastore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecretsTypeConstant
{
    [Description("AccountKey")]
    AccountKey,

    [Description("Certificate")]
    Certificate,

    [Description("KerberosKeytab")]
    KerberosKeytab,

    [Description("KerberosPassword")]
    KerberosPassword,

    [Description("Sas")]
    Sas,

    [Description("ServicePrincipal")]
    ServicePrincipal,
}
