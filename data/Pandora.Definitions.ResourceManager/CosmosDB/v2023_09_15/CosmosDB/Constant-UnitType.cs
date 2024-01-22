// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnitTypeConstant
{
    [Description("Bytes")]
    Bytes,

    [Description("BytesPerSecond")]
    BytesPerSecond,

    [Description("Count")]
    Count,

    [Description("CountPerSecond")]
    CountPerSecond,

    [Description("Milliseconds")]
    Milliseconds,

    [Description("Percent")]
    Percent,

    [Description("Seconds")]
    Seconds,
}
