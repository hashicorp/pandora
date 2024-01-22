// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureScaleTypeConstant
{
    [Description("automatic")]
    Automatic,

    [Description("manual")]
    Manual,

    [Description("none")]
    None,
}
