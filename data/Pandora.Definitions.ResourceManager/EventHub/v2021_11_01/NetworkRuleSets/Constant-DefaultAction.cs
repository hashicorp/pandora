using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.NetworkRuleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
