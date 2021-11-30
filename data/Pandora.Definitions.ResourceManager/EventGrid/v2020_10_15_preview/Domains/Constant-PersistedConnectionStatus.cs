using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Domains
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PersistedConnectionStatusConstant
    {
        [Description("Approved")]
        Approved,

        [Description("Disconnected")]
        Disconnected,

        [Description("Pending")]
        Pending,

        [Description("Rejected")]
        Rejected,
    }
}
