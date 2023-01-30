using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Orders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OrderStateConstant
{
    [Description("Arriving")]
    Arriving,

    [Description("AwaitingDrop")]
    AwaitingDrop,

    [Description("AwaitingFulfilment")]
    AwaitingFulfilment,

    [Description("AwaitingPickup")]
    AwaitingPickup,

    [Description("AwaitingPreparation")]
    AwaitingPreparation,

    [Description("AwaitingReturnShipment")]
    AwaitingReturnShipment,

    [Description("AwaitingShipment")]
    AwaitingShipment,

    [Description("CollectedAtMicrosoft")]
    CollectedAtMicrosoft,

    [Description("Declined")]
    Declined,

    [Description("Delivered")]
    Delivered,

    [Description("LostDevice")]
    LostDevice,

    [Description("PickupCompleted")]
    PickupCompleted,

    [Description("ReplacementRequested")]
    ReplacementRequested,

    [Description("ReturnInitiated")]
    ReturnInitiated,

    [Description("Shipped")]
    Shipped,

    [Description("ShippedBack")]
    ShippedBack,

    [Description("Untracked")]
    Untracked,
}
