// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityProvidersConstant
{
    [Description("ActiveDirectory")]
    ActiveDirectory,

    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,
}
