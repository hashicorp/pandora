// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KPackBuildStageProvisioningStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("NotStarted")]
    NotStarted,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,
}
