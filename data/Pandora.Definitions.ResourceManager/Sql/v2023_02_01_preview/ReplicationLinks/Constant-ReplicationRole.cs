// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("Copy")]
    Copy,

    [Description("NonReadableSecondary")]
    NonReadableSecondary,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("Source")]
    Source,
}
