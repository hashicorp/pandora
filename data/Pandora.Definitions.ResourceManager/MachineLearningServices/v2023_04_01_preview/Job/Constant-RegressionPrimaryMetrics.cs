// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegressionPrimaryMetricsConstant
{
    [Description("NormalizedMeanAbsoluteError")]
    NormalizedMeanAbsoluteError,

    [Description("NormalizedRootMeanSquaredError")]
    NormalizedRootMeanSquaredError,

    [Description("R2Score")]
    RTwoScore,

    [Description("SpearmanCorrelation")]
    SpearmanCorrelation,
}
