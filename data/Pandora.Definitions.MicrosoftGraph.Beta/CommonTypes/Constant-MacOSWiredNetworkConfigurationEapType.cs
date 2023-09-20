// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSWiredNetworkConfigurationEapTypeConstant
{
    [Description("EapTls")]
    @eapTls,

    [Description("Leap")]
    @leap,

    [Description("EapSim")]
    @eapSim,

    [Description("EapTtls")]
    @eapTtls,

    [Description("Peap")]
    @peap,

    [Description("EapFast")]
    @eapFast,

    [Description("Teap")]
    @teap,
}
