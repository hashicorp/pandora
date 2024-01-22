// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HashingAlgorithmConstant
{
    [Description("MD5")]
    MDFive,

    [Description("None")]
    None,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("SHA1")]
    SHAOne,

    [Description("SHA2512")]
    SHATwoFiveOneTwo,

    [Description("SHA2384")]
    SHATwoThreeEightFour,

    [Description("SHA2256")]
    SHATwoTwoFiveSix,
}
