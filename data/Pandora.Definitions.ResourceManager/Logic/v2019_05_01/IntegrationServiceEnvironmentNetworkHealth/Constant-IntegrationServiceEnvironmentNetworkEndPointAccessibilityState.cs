// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentNetworkHealth;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationServiceEnvironmentNetworkEndPointAccessibilityStateConstant
{
    [Description("Available")]
    Available,

    [Description("NotAvailable")]
    NotAvailable,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Unknown")]
    Unknown,
}
