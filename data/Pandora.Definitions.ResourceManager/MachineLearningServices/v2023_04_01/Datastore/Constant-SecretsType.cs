using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.Datastore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecretsTypeConstant
{
    [Description("AccountKey")]
    AccountKey,

    [Description("Certificate")]
    Certificate,

    [Description("Sas")]
    Sas,

    [Description("ServicePrincipal")]
    ServicePrincipal,
}
