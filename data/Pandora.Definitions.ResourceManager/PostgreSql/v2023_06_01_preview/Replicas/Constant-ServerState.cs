// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Dropping")]
    Dropping,

    [Description("Ready")]
    Ready,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Updating")]
    Updating,
}
