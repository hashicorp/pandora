// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2023_05_01.ContainerInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerGroupSkuConstant
{
    [Description("Confidential")]
    Confidential,

    [Description("Dedicated")]
    Dedicated,

    [Description("Standard")]
    Standard,
}
