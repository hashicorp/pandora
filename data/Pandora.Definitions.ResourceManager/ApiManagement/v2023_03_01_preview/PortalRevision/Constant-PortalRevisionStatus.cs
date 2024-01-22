// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.PortalRevision;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PortalRevisionStatusConstant
{
    [Description("completed")]
    Completed,

    [Description("failed")]
    Failed,

    [Description("pending")]
    Pending,

    [Description("publishing")]
    Publishing,
}
