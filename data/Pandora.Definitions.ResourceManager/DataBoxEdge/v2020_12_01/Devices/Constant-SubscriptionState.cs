using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubscriptionStateConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("Registered")]
    Registered,

    [Description("Suspended")]
    Suspended,

    [Description("Unregistered")]
    Unregistered,

    [Description("Warned")]
    Warned,
}
