using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Bot;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MsaAppTypeConstant
{
    [Description("MultiTenant")]
    MultiTenant,

    [Description("SingleTenant")]
    SingleTenant,

    [Description("UserAssignedMSI")]
    UserAssignedMSI,
}
