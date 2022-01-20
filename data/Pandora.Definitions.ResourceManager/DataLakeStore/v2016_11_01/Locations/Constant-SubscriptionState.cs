using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Locations;

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
