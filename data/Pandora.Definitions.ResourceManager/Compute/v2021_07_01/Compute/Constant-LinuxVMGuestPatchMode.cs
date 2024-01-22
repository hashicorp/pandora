// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.Compute;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LinuxVMGuestPatchModeConstant
{
    [Description("AutomaticByPlatform")]
    AutomaticByPlatform,

    [Description("ImageDefault")]
    ImageDefault,
}
