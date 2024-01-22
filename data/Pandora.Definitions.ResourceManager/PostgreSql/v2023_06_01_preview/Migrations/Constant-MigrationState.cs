// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("CleaningUp")]
    CleaningUp,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,

    [Description("ValidationFailed")]
    ValidationFailed,

    [Description("WaitingForUserAction")]
    WaitingForUserAction,
}
