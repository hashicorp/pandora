// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_05_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceLevelConstant
{
    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,

    [Description("StandardZRS")]
    StandardZRS,

    [Description("Ultra")]
    Ultra,
}
