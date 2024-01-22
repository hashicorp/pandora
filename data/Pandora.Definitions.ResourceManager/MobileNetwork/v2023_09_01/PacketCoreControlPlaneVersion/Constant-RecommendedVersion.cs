// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCoreControlPlaneVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedVersionConstant
{
    [Description("NotRecommended")]
    NotRecommended,

    [Description("Recommended")]
    Recommended,
}
