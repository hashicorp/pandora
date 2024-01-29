// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.SyncMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncMemberDbTypeConstant
{
    [Description("AzureSqlDatabase")]
    AzureSqlDatabase,

    [Description("SqlServerDatabase")]
    SqlServerDatabase,
}
