// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSContentCachingParentSelectionPolicyConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("RoundRobin")]
    @roundRobin,

    [Description("FirstAvailable")]
    @firstAvailable,

    [Description("UrlPathHash")]
    @urlPathHash,

    [Description("Random")]
    @random,

    [Description("StickyAvailable")]
    @stickyAvailable,
}
