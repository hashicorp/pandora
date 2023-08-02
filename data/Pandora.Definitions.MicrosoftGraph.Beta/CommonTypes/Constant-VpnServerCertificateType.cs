// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnServerCertificateTypeConstant
{
    [Description("Rsa")]
    @rsa,

    [Description("Ecdsa256")]
    @ecdsa256,

    [Description("Ecdsa384")]
    @ecdsa384,

    [Description("Ecdsa521")]
    @ecdsa521,
}
