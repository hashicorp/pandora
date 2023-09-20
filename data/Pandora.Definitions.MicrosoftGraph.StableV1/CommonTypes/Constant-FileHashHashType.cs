// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileHashHashTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Sha1")]
    @sha1,

    [Description("Sha256")]
    @sha256,

    [Description("Md5")]
    @md5,

    [Description("AuthenticodeHash256")]
    @authenticodeHash256,

    [Description("LsHash")]
    @lsHash,

    [Description("Ctph")]
    @ctph,
}
