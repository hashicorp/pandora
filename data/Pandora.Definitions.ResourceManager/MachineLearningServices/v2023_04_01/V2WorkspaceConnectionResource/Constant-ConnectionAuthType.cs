using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.V2WorkspaceConnectionResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionAuthTypeConstant
{
    [Description("ManagedIdentity")]
    ManagedIdentity,

    [Description("None")]
    None,

    [Description("PAT")]
    PAT,

    [Description("SAS")]
    SAS,

    [Description("UsernamePassword")]
    UsernamePassword,
}
