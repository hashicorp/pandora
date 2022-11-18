using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.BlobContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImmutabilityPolicyUpdateTypeConstant
{
    [Description("extend")]
    Extend,

    [Description("lock")]
    Lock,

    [Description("put")]
    Put,
}
