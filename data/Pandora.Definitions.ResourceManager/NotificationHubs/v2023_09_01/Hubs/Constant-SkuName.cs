// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Hubs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,

    [Description("Standard")]
    Standard,
}
