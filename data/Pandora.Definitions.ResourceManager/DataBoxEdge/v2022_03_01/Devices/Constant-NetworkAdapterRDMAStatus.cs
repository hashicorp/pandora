// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkAdapterRDMAStatusConstant
{
    [Description("Capable")]
    Capable,

    [Description("Incapable")]
    Incapable,
}
