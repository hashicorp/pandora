// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BaseImageDependencyTypeConstant
{
    [Description("BuildTime")]
    BuildTime,

    [Description("RunTime")]
    RunTime,
}
