using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ConnectionStatus
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
