using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataReference;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataReferenceCredentialTypeConstant
{
    [Description("DockerCredentials")]
    DockerCredentials,

    [Description("ManagedIdentity")]
    ManagedIdentity,

    [Description("NoCredentials")]
    NoCredentials,

    [Description("SAS")]
    SAS,
}
