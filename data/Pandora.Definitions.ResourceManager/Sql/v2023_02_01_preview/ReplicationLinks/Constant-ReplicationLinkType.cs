// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationLinkTypeConstant
{
    [Description("GEO")]
    GEO,

    [Description("NAMED")]
    NAMED,

    [Description("STANDBY")]
    STANDBY,
}
