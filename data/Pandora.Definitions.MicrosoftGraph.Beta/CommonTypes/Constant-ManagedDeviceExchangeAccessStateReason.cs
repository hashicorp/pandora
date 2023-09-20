// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceExchangeAccessStateReasonConstant
{
    [Description("None")]
    @none,

    [Description("Unknown")]
    @unknown,

    [Description("ExchangeGlobalRule")]
    @exchangeGlobalRule,

    [Description("ExchangeIndividualRule")]
    @exchangeIndividualRule,

    [Description("ExchangeDeviceRule")]
    @exchangeDeviceRule,

    [Description("ExchangeUpgrade")]
    @exchangeUpgrade,

    [Description("ExchangeMailboxPolicy")]
    @exchangeMailboxPolicy,

    [Description("Other")]
    @other,

    [Description("Compliant")]
    @compliant,

    [Description("NotCompliant")]
    @notCompliant,

    [Description("NotEnrolled")]
    @notEnrolled,

    [Description("UnknownLocation")]
    @unknownLocation,

    [Description("MfaRequired")]
    @mfaRequired,

    [Description("AzureADBlockDueToAccessPolicy")]
    @azureADBlockDueToAccessPolicy,

    [Description("CompromisedPassword")]
    @compromisedPassword,

    [Description("DeviceNotKnownWithManagedApp")]
    @deviceNotKnownWithManagedApp,
}
