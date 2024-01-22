// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Users;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ShareAccessTypeConstant
{
    [Description("Change")]
    Change,

    [Description("Custom")]
    Custom,

    [Description("Read")]
    Read,
}
