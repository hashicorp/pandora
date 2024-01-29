// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeleteStatusConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("NotDeleted")]
    NotDeleted,

    [Description("Unspecified")]
    Unspecified,
}
