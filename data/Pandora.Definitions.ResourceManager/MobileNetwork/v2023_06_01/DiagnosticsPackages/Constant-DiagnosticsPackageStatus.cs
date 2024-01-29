// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.DiagnosticsPackages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiagnosticsPackageStatusConstant
{
    [Description("Collected")]
    Collected,

    [Description("Collecting")]
    Collecting,

    [Description("Error")]
    Error,

    [Description("NotStarted")]
    NotStarted,
}
