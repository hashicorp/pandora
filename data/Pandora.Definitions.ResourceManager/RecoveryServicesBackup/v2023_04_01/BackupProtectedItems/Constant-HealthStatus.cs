// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthStatusConstant
{
    [Description("ActionRequired")]
    ActionRequired,

    [Description("ActionSuggested")]
    ActionSuggested,

    [Description("Invalid")]
    Invalid,

    [Description("Passed")]
    Passed,
}
