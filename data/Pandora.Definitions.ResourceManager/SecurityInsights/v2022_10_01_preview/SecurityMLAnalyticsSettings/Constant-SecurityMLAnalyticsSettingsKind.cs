// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SecurityMLAnalyticsSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityMLAnalyticsSettingsKindConstant
{
    [Description("Anomaly")]
    Anomaly,
}
