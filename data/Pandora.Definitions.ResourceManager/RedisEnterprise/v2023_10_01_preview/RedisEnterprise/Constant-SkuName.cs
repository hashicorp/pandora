// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Enterprise_E5")]
    EnterpriseEFive,

    [Description("Enterprise_E50")]
    EnterpriseEFiveZero,

    [Description("Enterprise_E400")]
    EnterpriseEFourHundred,

    [Description("Enterprise_E100")]
    EnterpriseEOneHundred,

    [Description("Enterprise_E10")]
    EnterpriseEOneZero,

    [Description("Enterprise_E200")]
    EnterpriseETwoHundred,

    [Description("Enterprise_E20")]
    EnterpriseETwoZero,

    [Description("EnterpriseFlash_F1500")]
    EnterpriseFlashFOneFiveHundred,

    [Description("EnterpriseFlash_F700")]
    EnterpriseFlashFSevenHundred,

    [Description("EnterpriseFlash_F300")]
    EnterpriseFlashFThreeHundred,
}
