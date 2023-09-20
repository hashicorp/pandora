// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MessageRecipientDeliveryStatusConstant
{
    [Description("GettingStatus")]
    @gettingStatus,

    [Description("Pending")]
    @pending,

    [Description("Failed")]
    @failed,

    [Description("Delivered")]
    @delivered,

    [Description("Expanded")]
    @expanded,

    [Description("Quarantined")]
    @quarantined,

    [Description("FilteredAsSpam")]
    @filteredAsSpam,
}
