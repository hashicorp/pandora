// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.JitRequests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JitRequestStateConstant
{
    [Description("Approved")]
    Approved,

    [Description("Canceled")]
    Canceled,

    [Description("Denied")]
    Denied,

    [Description("Expired")]
    Expired,

    [Description("Failed")]
    Failed,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Pending")]
    Pending,

    [Description("Timeout")]
    Timeout,
}
