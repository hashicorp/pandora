// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_08_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiagnosticLevelConstant
{
    [Description("Basic")]
    Basic,

    [Description("Enhanced")]
    Enhanced,

    [Description("Off")]
    Off,
}
