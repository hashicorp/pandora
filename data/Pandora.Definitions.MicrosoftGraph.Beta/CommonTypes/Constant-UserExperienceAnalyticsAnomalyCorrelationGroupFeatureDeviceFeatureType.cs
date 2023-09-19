// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserExperienceAnalyticsAnomalyCorrelationGroupFeatureDeviceFeatureTypeConstant
{
    [Description("Manufacturer")]
    @manufacturer,

    [Description("Model")]
    @model,

    [Description("OsVersion")]
    @osVersion,

    [Description("Application")]
    @application,

    [Description("Driver")]
    @driver,
}
