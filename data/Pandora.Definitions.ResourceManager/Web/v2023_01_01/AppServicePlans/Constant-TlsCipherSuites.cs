// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServicePlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TlsCipherSuitesConstant
{
    [Description("TLS_AES_128_GCM_SHA256")]
    TLSAESOneTwoEightGCMSHATwoFiveSix,

    [Description("TLS_AES_256_GCM_SHA384")]
    TLSAESTwoFiveSixGCMSHAThreeEightFour,

    [Description("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256")]
    TLSECDHEECDSAWITHAESOneTwoEightCBCSHATwoFiveSix,

    [Description("TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256")]
    TLSECDHEECDSAWITHAESOneTwoEightGCMSHATwoFiveSix,

    [Description("TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384")]
    TLSECDHEECDSAWITHAESTwoFiveSixGCMSHAThreeEightFour,

    [Description("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA")]
    TLSECDHERSAWITHAESOneTwoEightCBCSHA,

    [Description("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256")]
    TLSECDHERSAWITHAESOneTwoEightCBCSHATwoFiveSix,

    [Description("TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256")]
    TLSECDHERSAWITHAESOneTwoEightGCMSHATwoFiveSix,

    [Description("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA")]
    TLSECDHERSAWITHAESTwoFiveSixCBCSHA,

    [Description("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384")]
    TLSECDHERSAWITHAESTwoFiveSixCBCSHAThreeEightFour,

    [Description("TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384")]
    TLSECDHERSAWITHAESTwoFiveSixGCMSHAThreeEightFour,

    [Description("TLS_RSA_WITH_AES_128_CBC_SHA")]
    TLSRSAWITHAESOneTwoEightCBCSHA,

    [Description("TLS_RSA_WITH_AES_128_CBC_SHA256")]
    TLSRSAWITHAESOneTwoEightCBCSHATwoFiveSix,

    [Description("TLS_RSA_WITH_AES_128_GCM_SHA256")]
    TLSRSAWITHAESOneTwoEightGCMSHATwoFiveSix,

    [Description("TLS_RSA_WITH_AES_256_CBC_SHA")]
    TLSRSAWITHAESTwoFiveSixCBCSHA,

    [Description("TLS_RSA_WITH_AES_256_CBC_SHA256")]
    TLSRSAWITHAESTwoFiveSixCBCSHATwoFiveSix,

    [Description("TLS_RSA_WITH_AES_256_GCM_SHA384")]
    TLSRSAWITHAESTwoFiveSixGCMSHAThreeEightFour,
}
