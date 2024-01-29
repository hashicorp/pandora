// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsernameSourceConstant
{
    [Description("AD")]
    AD,

    [Description("File")]
    File,

    [Description("LDAP")]
    LDAP,

    [Description("None")]
    None,
}
