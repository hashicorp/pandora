// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TestMigrationStateConstant
{
    [Description("None")]
    None,

    [Description("TestMigrationCleanupInProgress")]
    TestMigrationCleanupInProgress,

    [Description("TestMigrationCompletedWithInformation")]
    TestMigrationCompletedWithInformation,

    [Description("TestMigrationFailed")]
    TestMigrationFailed,

    [Description("TestMigrationInProgress")]
    TestMigrationInProgress,

    [Description("TestMigrationPartiallySucceeded")]
    TestMigrationPartiallySucceeded,

    [Description("TestMigrationSucceeded")]
    TestMigrationSucceeded,
}
