// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationItemOperationConstant
{
    [Description("DisableMigration")]
    DisableMigration,

    [Description("Migrate")]
    Migrate,

    [Description("PauseReplication")]
    PauseReplication,

    [Description("ResumeReplication")]
    ResumeReplication,

    [Description("StartResync")]
    StartResync,

    [Description("TestMigrate")]
    TestMigrate,

    [Description("TestMigrateCleanup")]
    TestMigrateCleanup,
}
