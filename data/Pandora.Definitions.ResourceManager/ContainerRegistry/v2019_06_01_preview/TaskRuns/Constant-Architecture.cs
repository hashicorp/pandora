// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.TaskRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArchitectureConstant
{
    [Description("amd64")]
    AmdSixFour,

    [Description("arm")]
    Arm,

    [Description("arm64")]
    ArmSixFour,

    [Description("386")]
    ThreeEightSix,

    [Description("x86")]
    XEightSix,
}
