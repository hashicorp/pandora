// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlatformVersionConstant
{
    [Description("mtv1")]
    MtvOne,

    [Description("stv1")]
    StvOne,

    [Description("stv2")]
    StvTwo,

    [Description("stv2.1")]
    StvTwoPointOne,

    [Description("undetermined")]
    Undetermined,
}
