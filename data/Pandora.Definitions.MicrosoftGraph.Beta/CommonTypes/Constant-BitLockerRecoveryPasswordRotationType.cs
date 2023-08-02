// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BitLockerRecoveryPasswordRotationTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Disabled")]
    @disabled,

    [Description("EnabledForAzureAd")]
    @enabledForAzureAd,

    [Description("EnabledForAzureAdAndHybrid")]
    @enabledForAzureAdAndHybrid,
}
