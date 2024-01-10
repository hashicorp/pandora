using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NetworkRuleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkRuleIPActionConstant
{
    [Description("Allow")]
    Allow,
}
