// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosVpnSecurityAssociationParametersSecurityIntegrityAlgorithmConstant
{
    [Description("Sha2256")]
    @sha2_256,

    [Description("Sha196")]
    @sha1_96,

    [Description("Sha1160")]
    @sha1_160,

    [Description("Sha2384")]
    @sha2_384,

    [Description("Sha2512")]
    @sha2_512,

    [Description("Md5")]
    @md5,
}
