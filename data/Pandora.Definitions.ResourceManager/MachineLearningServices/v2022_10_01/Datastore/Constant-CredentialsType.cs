using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Datastore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialsTypeConstant
{
    [Description("AccountKey")]
    AccountKey,

    [Description("Certificate")]
    Certificate,

    [Description("None")]
    None,

    [Description("Sas")]
    Sas,

    [Description("ServicePrincipal")]
    ServicePrincipal,
}
