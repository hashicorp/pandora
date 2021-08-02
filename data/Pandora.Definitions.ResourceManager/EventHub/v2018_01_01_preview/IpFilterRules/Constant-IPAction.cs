using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.IpFilterRules
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum IPActionConstant
    {
        [Description("Accept")]
        Accept,

        [Description("Reject")]
        Reject,
    }
}
