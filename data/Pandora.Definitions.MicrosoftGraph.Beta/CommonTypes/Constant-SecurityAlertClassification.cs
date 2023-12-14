// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityAlertClassificationConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("FalsePositive")]
    @falsePositive,

    [Description("TruePositive")]
    @truePositive,

    [Description("InformationalExpectedActivity")]
    @informationalExpectedActivity,
}
