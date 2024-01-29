// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_05_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PersistentVolumeRestoreModeConstant
{
    [Description("RestoreWithVolumeData")]
    RestoreWithVolumeData,

    [Description("RestoreWithoutVolumeData")]
    RestoreWithoutVolumeData,
}
