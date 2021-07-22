using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetWorkRuleSets
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DefaultAction
    {
        [Description("Allow")]
        Allow,

        [Description("Deny")]
        Deny,
    }
}
