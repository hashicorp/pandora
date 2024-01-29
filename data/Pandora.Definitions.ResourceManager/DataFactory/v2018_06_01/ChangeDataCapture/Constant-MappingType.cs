// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ChangeDataCapture;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MappingTypeConstant
{
    [Description("Aggregate")]
    Aggregate,

    [Description("Derived")]
    Derived,

    [Description("Direct")]
    Direct,
}
