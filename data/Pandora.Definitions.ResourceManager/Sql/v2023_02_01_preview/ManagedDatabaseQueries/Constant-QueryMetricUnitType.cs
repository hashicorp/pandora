// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabaseQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryMetricUnitTypeConstant
{
    [Description("count")]
    Count,

    [Description("KB")]
    KB,

    [Description("microseconds")]
    Microseconds,

    [Description("percentage")]
    Percentage,
}
