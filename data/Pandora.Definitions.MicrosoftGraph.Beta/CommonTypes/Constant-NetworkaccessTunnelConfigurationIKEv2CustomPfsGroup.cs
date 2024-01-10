// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessTunnelConfigurationIKEv2CustomPfsGroupConstant
{
    [Description("None")]
    @none,

    [Description("Pfs1")]
    @pfs1,

    [Description("Pfs2")]
    @pfs2,

    [Description("Pfs14")]
    @pfs14,

    [Description("Pfs24")]
    @pfs24,

    [Description("Pfs2048")]
    @pfs2048,

    [Description("Pfsmm")]
    @pfsmm,

    [Description("Ecp256")]
    @ecp256,

    [Description("Ecp384")]
    @ecp384,
}
