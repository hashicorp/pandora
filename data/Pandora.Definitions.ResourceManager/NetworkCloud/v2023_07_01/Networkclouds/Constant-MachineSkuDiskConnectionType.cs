// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MachineSkuDiskConnectionTypeConstant
{
    [Description("PCIE")]
    PCIE,

    [Description("RAID")]
    RAID,

    [Description("SAS")]
    SAS,

    [Description("SATA")]
    SATA,
}
