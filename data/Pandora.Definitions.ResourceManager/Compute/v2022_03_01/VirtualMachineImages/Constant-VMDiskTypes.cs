// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMDiskTypesConstant
{
    [Description("None")]
    None,

    [Description("Unmanaged")]
    Unmanaged,
}
