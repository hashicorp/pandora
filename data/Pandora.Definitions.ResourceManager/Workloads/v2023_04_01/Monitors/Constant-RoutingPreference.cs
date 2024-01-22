// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoutingPreferenceConstant
{
    [Description("Default")]
    Default,

    [Description("RouteAll")]
    RouteAll,
}
