// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignInCrossTenantAccessTypeConstant
{
    [Description("None")]
    @none,

    [Description("B2bCollaboration")]
    @b2bCollaboration,

    [Description("B2bDirectConnect")]
    @b2bDirectConnect,

    [Description("MicrosoftSupport")]
    @microsoftSupport,

    [Description("ServiceProvider")]
    @serviceProvider,

    [Description("Passthrough")]
    @passthrough,
}
