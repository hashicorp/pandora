// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CryptographySuiteEncryptionMethodConstant
{
    [Description("Aes256")]
    @aes256,

    [Description("Des")]
    @des,

    [Description("TripleDes")]
    @tripleDes,

    [Description("Aes128")]
    @aes128,

    [Description("Aes128Gcm")]
    @aes128Gcm,

    [Description("Aes256Gcm")]
    @aes256Gcm,

    [Description("Aes192")]
    @aes192,

    [Description("Aes192Gcm")]
    @aes192Gcm,

    [Description("ChaCha20Poly1305")]
    @chaCha20Poly1305,
}
