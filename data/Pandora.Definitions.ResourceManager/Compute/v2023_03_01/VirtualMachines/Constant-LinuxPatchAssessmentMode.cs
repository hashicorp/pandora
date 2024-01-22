// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LinuxPatchAssessmentModeConstant
{
    [Description("AutomaticByPlatform")]
    AutomaticByPlatform,

    [Description("ImageDefault")]
    ImageDefault,
}
