// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDevicePartnerReportedHealthStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Activated")]
    @activated,

    [Description("Deactivated")]
    @deactivated,

    [Description("Secured")]
    @secured,

    [Description("LowSeverity")]
    @lowSeverity,

    [Description("MediumSeverity")]
    @mediumSeverity,

    [Description("HighSeverity")]
    @highSeverity,

    [Description("Unresponsive")]
    @unresponsive,

    [Description("Compromised")]
    @compromised,

    [Description("Misconfigured")]
    @misconfigured,
}
