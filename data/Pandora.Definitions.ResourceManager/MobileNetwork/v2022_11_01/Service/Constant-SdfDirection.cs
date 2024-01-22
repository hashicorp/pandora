// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.Service;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SdfDirectionConstant
{
    [Description("Bidirectional")]
    Bidirectional,

    [Description("Downlink")]
    Downlink,

    [Description("Uplink")]
    Uplink,
}
