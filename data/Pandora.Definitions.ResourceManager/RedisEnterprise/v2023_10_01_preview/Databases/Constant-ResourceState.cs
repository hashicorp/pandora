// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceStateConstant
{
    [Description("CreateFailed")]
    CreateFailed,

    [Description("Creating")]
    Creating,

    [Description("DeleteFailed")]
    DeleteFailed,

    [Description("Deleting")]
    Deleting,

    [Description("DisableFailed")]
    DisableFailed,

    [Description("Disabled")]
    Disabled,

    [Description("Disabling")]
    Disabling,

    [Description("EnableFailed")]
    EnableFailed,

    [Description("Enabling")]
    Enabling,

    [Description("Running")]
    Running,

    [Description("Scaling")]
    Scaling,

    [Description("ScalingFailed")]
    ScalingFailed,

    [Description("UpdateFailed")]
    UpdateFailed,

    [Description("Updating")]
    Updating,
}
