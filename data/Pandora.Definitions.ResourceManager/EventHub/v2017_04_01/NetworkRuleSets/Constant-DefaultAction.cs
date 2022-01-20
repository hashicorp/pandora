using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetworkRuleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
