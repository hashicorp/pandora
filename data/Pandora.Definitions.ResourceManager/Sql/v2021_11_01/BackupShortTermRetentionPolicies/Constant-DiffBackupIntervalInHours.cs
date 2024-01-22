// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.BackupShortTermRetentionPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum DiffBackupIntervalInHoursConstant
{
    [Description("12")]
    OneTwo,

    [Description("24")]
    TwoFour,
}
