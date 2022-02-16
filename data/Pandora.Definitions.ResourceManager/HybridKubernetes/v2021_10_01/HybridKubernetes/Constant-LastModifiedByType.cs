using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LastModifiedByTypeConstant
{
    [Description("Application")]
    Application,

    [Description("Key")]
    Key,

    [Description("ManagedIdentity")]
    ManagedIdentity,

    [Description("User")]
    User,
}
