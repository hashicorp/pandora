using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum SignalRSkuTier
    {
        [Description("Basic")]
        Basic,

        [Description("Free")]
        Free,

        [Description("Premium")]
        Premium,

        [Description("Standard")]
        Standard,
    }
}
