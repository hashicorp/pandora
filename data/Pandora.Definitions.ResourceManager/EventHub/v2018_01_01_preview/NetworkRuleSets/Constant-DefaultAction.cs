using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
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
