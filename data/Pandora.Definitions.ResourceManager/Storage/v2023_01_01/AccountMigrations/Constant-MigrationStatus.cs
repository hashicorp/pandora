// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.AccountMigrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationStatusConstant
{
    [Description("Complete")]
    Complete,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Invalid")]
    Invalid,

    [Description("SubmittedForConversion")]
    SubmittedForConversion,
}
