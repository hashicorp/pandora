// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncGroupsTypeConstant
{
    [Description("All")]
    All,

    [Description("Error")]
    Error,

    [Description("Success")]
    Success,

    [Description("Warning")]
    Warning,
}
