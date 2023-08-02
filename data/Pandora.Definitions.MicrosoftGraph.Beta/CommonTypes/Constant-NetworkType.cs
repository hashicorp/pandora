// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkTypeConstant
{
    [Description("Intranet")]
    @intranet,

    [Description("Extranet")]
    @extranet,

    [Description("NamedNetwork")]
    @namedNetwork,

    [Description("Trusted")]
    @trusted,

    [Description("TrustedNamedLocation")]
    @trustedNamedLocation,
}
