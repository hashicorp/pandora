// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.EventHubsClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterSkuNameConstant
{
    [Description("Dedicated")]
    Dedicated,
}
