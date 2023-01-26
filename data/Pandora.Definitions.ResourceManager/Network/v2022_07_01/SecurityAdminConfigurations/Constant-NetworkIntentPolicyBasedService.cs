using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.SecurityAdminConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkIntentPolicyBasedServiceConstant
{
    [Description("All")]
    All,

    [Description("AllowRulesOnly")]
    AllowRulesOnly,

    [Description("None")]
    None,
}
