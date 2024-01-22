// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Regions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyEncryptionAlgorithmConstant
{
    [Description("RSA-OAEP")]
    RSANegativeOAEP,

    [Description("RSA-OAEP-256")]
    RSANegativeOAEPNegativeTwoFiveSix,

    [Description("RSA1_5")]
    RSAOneFive,
}
