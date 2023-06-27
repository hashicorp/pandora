using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIM;

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
