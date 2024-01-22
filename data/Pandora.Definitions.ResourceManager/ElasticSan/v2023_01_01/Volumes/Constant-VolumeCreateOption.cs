// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeCreateOptionConstant
{
    [Description("Disk")]
    Disk,

    [Description("DiskRestorePoint")]
    DiskRestorePoint,

    [Description("DiskSnapshot")]
    DiskSnapshot,

    [Description("None")]
    None,

    [Description("VolumeSnapshot")]
    VolumeSnapshot,
}
