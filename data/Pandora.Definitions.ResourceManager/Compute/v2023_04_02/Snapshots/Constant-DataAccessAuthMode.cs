// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataAccessAuthModeConstant
{
    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("None")]
    None,
}
