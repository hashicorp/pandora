// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngestionModeConstant
{
    [Description("ApplicationInsights")]
    ApplicationInsights,

    [Description("ApplicationInsightsWithDiagnosticSettings")]
    ApplicationInsightsWithDiagnosticSettings,

    [Description("LogAnalytics")]
    LogAnalytics,
}
