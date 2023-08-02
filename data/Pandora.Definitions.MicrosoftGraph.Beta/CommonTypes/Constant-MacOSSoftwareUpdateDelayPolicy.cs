// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSSoftwareUpdateDelayPolicyConstant
{
    [Description("None")]
    @none,

    [Description("DelayOSUpdateVisibility")]
    @delayOSUpdateVisibility,

    [Description("DelayAppUpdateVisibility")]
    @delayAppUpdateVisibility,

    [Description("DelayMajorOsUpdateVisibility")]
    @delayMajorOsUpdateVisibility,
}
