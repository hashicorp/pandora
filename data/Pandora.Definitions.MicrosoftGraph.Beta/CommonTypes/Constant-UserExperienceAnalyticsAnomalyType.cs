// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserExperienceAnalyticsAnomalyTypeConstant
{
    [Description("Device")]
    @device,

    [Description("Application")]
    @application,

    [Description("StopError")]
    @stopError,

    [Description("Driver")]
    @driver,

    [Description("Other")]
    @other,
}
