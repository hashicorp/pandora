// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DataMaskingRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataMaskingFunctionConstant
{
    [Description("CCN")]
    CCN,

    [Description("Default")]
    Default,

    [Description("Email")]
    Email,

    [Description("Number")]
    Number,

    [Description("SSN")]
    SSN,

    [Description("Text")]
    Text,
}
