// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkerSizeOptionsConstant
{
    [Description("D1")]
    DOne,

    [Description("D3")]
    DThree,

    [Description("D2")]
    DTwo,

    [Description("Default")]
    Default,

    [Description("Large")]
    Large,

    [Description("LargeV3")]
    LargeVThree,

    [Description("Medium")]
    Medium,

    [Description("MediumV3")]
    MediumVThree,

    [Description("NestedSmall")]
    NestedSmall,

    [Description("NestedSmallLinux")]
    NestedSmallLinux,

    [Description("Small")]
    Small,

    [Description("SmallV3")]
    SmallVThree,
}
