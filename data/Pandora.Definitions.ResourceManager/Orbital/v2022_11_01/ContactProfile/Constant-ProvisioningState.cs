using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_11_01.ContactProfile;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("canceled")]
    Canceled,

    [Description("creating")]
    Creating,

    [Description("deleting")]
    Deleting,

    [Description("failed")]
    Failed,

    [Description("succeeded")]
    Succeeded,

    [Description("updating")]
    Updating,
}
