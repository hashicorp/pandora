// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BitLockerSystemDrivePolicyEncryptionMethodConstant
{
    [Description("AesCbc128")]
    @aesCbc128,

    [Description("AesCbc256")]
    @aesCbc256,

    [Description("XtsAes128")]
    @xtsAes128,

    [Description("XtsAes256")]
    @xtsAes256,
}
