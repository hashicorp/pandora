// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsManagedDevicePartnerReportedThreatStateConstant
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
