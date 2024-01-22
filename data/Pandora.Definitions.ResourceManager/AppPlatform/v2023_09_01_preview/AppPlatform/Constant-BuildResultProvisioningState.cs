// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BuildResultProvisioningStateConstant
{
    [Description("Building")]
    Building,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Queuing")]
    Queuing,

    [Description("Succeeded")]
    Succeeded,
}
