using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImmutabilityPolicyStateConstant
{
    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
