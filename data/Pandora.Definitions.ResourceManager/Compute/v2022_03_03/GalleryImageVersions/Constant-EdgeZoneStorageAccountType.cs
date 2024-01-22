// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImageVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EdgeZoneStorageAccountTypeConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("StandardSSD_LRS")]
    StandardSSDLRS,

    [Description("Standard_ZRS")]
    StandardZRS,
}
