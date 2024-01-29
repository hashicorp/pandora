// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ServerAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedActionCurrentStateConstant
{
    [Description("Active")]
    Active,

    [Description("Error")]
    Error,

    [Description("Executing")]
    Executing,

    [Description("Expired")]
    Expired,

    [Description("Ignored")]
    Ignored,

    [Description("Monitoring")]
    Monitoring,

    [Description("Pending")]
    Pending,

    [Description("PendingRevert")]
    PendingRevert,

    [Description("Resolved")]
    Resolved,

    [Description("RevertCancelled")]
    RevertCancelled,

    [Description("Reverted")]
    Reverted,

    [Description("Reverting")]
    Reverting,

    [Description("Success")]
    Success,

    [Description("Verifying")]
    Verifying,
}
