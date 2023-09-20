// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomExtensionCalloutInstanceStatusConstant
{
    [Description("CalloutSent")]
    @calloutSent,

    [Description("CallbackReceived")]
    @callbackReceived,

    [Description("CalloutFailed")]
    @calloutFailed,

    [Description("CallbackTimedOut")]
    @callbackTimedOut,

    [Description("WaitingForCallback")]
    @waitingForCallback,
}
