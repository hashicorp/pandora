// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserPfxPaddingSchemeConstant
{
    [Description("None")]
    @none,

    [Description("Pkcs1")]
    @pkcs1,

    [Description("OaepSha1")]
    @oaepSha1,

    [Description("OaepSha256")]
    @oaepSha256,

    [Description("OaepSha384")]
    @oaepSha384,

    [Description("OaepSha512")]
    @oaepSha512,
}
