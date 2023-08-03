// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RestrictionTriggerConstant
{
    [Description("CopyPaste")]
    @copyPaste,

    [Description("CopyToNetworkShare")]
    @copyToNetworkShare,

    [Description("CopyToRemovableMedia")]
    @copyToRemovableMedia,

    [Description("ScreenCapture")]
    @screenCapture,

    [Description("Print")]
    @print,

    [Description("CloudEgress")]
    @cloudEgress,

    [Description("UnallowedApps")]
    @unallowedApps,
}
