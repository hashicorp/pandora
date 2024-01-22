// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.CertificateOrdersDiagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InsightStatusConstant
{
    [Description("Critical")]
    Critical,

    [Description("Info")]
    Info,

    [Description("None")]
    None,

    [Description("Success")]
    Success,

    [Description("Warning")]
    Warning,
}
