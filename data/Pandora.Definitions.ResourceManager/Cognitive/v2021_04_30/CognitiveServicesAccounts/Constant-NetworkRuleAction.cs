using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkRuleActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
