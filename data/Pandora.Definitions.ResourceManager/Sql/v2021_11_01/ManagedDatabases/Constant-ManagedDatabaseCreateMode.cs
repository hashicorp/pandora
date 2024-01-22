// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDatabaseCreateModeConstant
{
    [Description("Default")]
    Default,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Recovery")]
    Recovery,

    [Description("RestoreExternalBackup")]
    RestoreExternalBackup,

    [Description("RestoreLongTermRetentionBackup")]
    RestoreLongTermRetentionBackup,
}
