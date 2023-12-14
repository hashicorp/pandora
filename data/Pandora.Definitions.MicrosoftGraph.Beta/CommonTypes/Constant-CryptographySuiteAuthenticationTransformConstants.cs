// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CryptographySuiteAuthenticationTransformConstantsConstant
{
    [Description("Md596")]
    @md5_96,

    [Description("Sha196")]
    @sha1_96,

    [Description("Sha256128")]
    @sha_256_128,

    [Description("Aes128Gcm")]
    @aes128Gcm,

    [Description("Aes192Gcm")]
    @aes192Gcm,

    [Description("Aes256Gcm")]
    @aes256Gcm,
}
