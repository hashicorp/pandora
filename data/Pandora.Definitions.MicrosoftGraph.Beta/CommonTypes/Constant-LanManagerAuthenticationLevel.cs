// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LanManagerAuthenticationLevelConstant
{
    [Description("LmAndNltm")]
    @lmAndNltm,

    [Description("LmNtlmAndNtlmV2")]
    @lmNtlmAndNtlmV2,

    [Description("LmAndNtlmOnly")]
    @lmAndNtlmOnly,

    [Description("LmAndNtlmV2")]
    @lmAndNtlmV2,

    [Description("LmNtlmV2AndNotLm")]
    @lmNtlmV2AndNotLm,

    [Description("LmNtlmV2AndNotLmOrNtm")]
    @lmNtlmV2AndNotLmOrNtm,
}
