// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_03_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoftwareAssuranceIntentConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,
}
