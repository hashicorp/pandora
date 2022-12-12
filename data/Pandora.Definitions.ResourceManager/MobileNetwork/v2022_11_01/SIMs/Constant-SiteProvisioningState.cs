using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SiteProvisioningStateConstant
{
    [Description("Adding")]
    Adding,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("Provisioned")]
    Provisioned,

    [Description("Updating")]
    Updating,
}
