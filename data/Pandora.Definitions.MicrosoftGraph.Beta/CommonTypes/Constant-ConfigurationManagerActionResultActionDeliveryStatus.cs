// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationManagerActionResultActionDeliveryStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("PendingDelivery")]
    @pendingDelivery,

    [Description("DeliveredToConnectorService")]
    @deliveredToConnectorService,

    [Description("FailedToDeliverToConnectorService")]
    @failedToDeliverToConnectorService,

    [Description("DeliveredToOnPremisesServer")]
    @deliveredToOnPremisesServer,
}
