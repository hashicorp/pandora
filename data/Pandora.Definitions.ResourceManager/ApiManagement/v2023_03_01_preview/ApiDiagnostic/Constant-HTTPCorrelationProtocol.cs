// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiDiagnostic;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HTTPCorrelationProtocolConstant
{
    [Description("Legacy")]
    Legacy,

    [Description("None")]
    None,

    [Description("W3C")]
    WThreeC,
}
