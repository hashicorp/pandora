using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.ContentKeyPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentKeyPolicyFairPlayRentalAndLeaseKeyTypeConstant
{
    [Description("DualExpiry")]
    DualExpiry,

    [Description("PersistentLimited")]
    PersistentLimited,

    [Description("PersistentUnlimited")]
    PersistentUnlimited,

    [Description("Undefined")]
    Undefined,

    [Description("Unknown")]
    Unknown,
}
