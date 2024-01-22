// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiIssue;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateConstant
{
    [Description("closed")]
    Closed,

    [Description("open")]
    Open,

    [Description("proposed")]
    Proposed,

    [Description("removed")]
    Removed,

    [Description("resolved")]
    Resolved,
}
