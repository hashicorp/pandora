// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.RecoveryPointsCrr;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointTierTypeConstant
{
    [Description("ArchivedRP")]
    ArchivedRP,

    [Description("HardenedRP")]
    HardenedRP,

    [Description("InstantRP")]
    InstantRP,

    [Description("Invalid")]
    Invalid,
}
