// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiVersionSet;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VersioningSchemeConstant
{
    [Description("Header")]
    Header,

    [Description("Query")]
    Query,

    [Description("Segment")]
    Segment,
}
