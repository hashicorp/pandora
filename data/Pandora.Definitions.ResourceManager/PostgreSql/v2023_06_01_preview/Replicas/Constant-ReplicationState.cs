// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationStateConstant
{
    [Description("Active")]
    Active,

    [Description("Broken")]
    Broken,

    [Description("Catchup")]
    Catchup,

    [Description("Provisioning")]
    Provisioning,

    [Description("Reconfiguring")]
    Reconfiguring,

    [Description("Updating")]
    Updating,
}
