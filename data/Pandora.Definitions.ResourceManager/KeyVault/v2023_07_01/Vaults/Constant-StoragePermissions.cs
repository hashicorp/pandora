// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_07_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StoragePermissionsConstant
{
    [Description("all")]
    All,

    [Description("backup")]
    Backup,

    [Description("delete")]
    Delete,

    [Description("deletesas")]
    Deletesas,

    [Description("get")]
    Get,

    [Description("getsas")]
    Getsas,

    [Description("list")]
    List,

    [Description("listsas")]
    Listsas,

    [Description("purge")]
    Purge,

    [Description("recover")]
    Recover,

    [Description("regeneratekey")]
    Regeneratekey,

    [Description("restore")]
    Restore,

    [Description("set")]
    Set,

    [Description("setsas")]
    Setsas,

    [Description("update")]
    Update,
}
