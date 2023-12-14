// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityFileHashAlgorithmConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Md5")]
    @md5,

    [Description("Sha1")]
    @sha1,

    [Description("Sha256")]
    @sha256,

    [Description("Sha256ac")]
    @sha256ac,
}
