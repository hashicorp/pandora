using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.ContentKeyPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentKeyPolicyPlayReadyLicenseTypeConstant
{
    [Description("NonPersistent")]
    NonPersistent,

    [Description("Persistent")]
    Persistent,

    [Description("Unknown")]
    Unknown,
}
