using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2022_10_31.DigitalTwinsInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionPropertiesProvisioningStateConstant
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
