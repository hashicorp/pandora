// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.CommunityGalleryImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArchitectureConstant
{
    [Description("Arm64")]
    ArmSixFour,

    [Description("x64")]
    XSixFour,
}
