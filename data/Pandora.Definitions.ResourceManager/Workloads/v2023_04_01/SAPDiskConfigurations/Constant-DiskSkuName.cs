// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDiskConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskSkuNameConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("PremiumV2_LRS")]
    PremiumVTwoLRS,

    [Description("Premium_ZRS")]
    PremiumZRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("StandardSSD_LRS")]
    StandardSSDLRS,

    [Description("StandardSSD_ZRS")]
    StandardSSDZRS,

    [Description("UltraSSD_LRS")]
    UltraSSDLRS,
}
