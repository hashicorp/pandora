using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Events;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventTypeConstant
{
    [Description("NewCredit")]
    NewCredit,

    [Description("PendingAdjustments")]
    PendingAdjustments,

    [Description("PendingCharges")]
    PendingCharges,

    [Description("PendingExpiredCredit")]
    PendingExpiredCredit,

    [Description("PendingNewCredit")]
    PendingNewCredit,

    [Description("SettledCharges")]
    SettledCharges,

    [Description("UnKnown")]
    UnKnown,
}
