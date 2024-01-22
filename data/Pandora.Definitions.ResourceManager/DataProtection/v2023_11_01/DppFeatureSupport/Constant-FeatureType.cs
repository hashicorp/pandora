// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.DppFeatureSupport;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureTypeConstant
{
    [Description("DataSourceType")]
    DataSourceType,

    [Description("Invalid")]
    Invalid,
}
