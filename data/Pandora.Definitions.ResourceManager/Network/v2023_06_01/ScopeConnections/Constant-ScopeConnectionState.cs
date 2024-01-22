// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.ScopeConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeConnectionStateConstant
{
    [Description("Conflict")]
    Conflict,

    [Description("Connected")]
    Connected,

    [Description("Pending")]
    Pending,

    [Description("Rejected")]
    Rejected,

    [Description("Revoked")]
    Revoked,
}
