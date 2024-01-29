// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.LabelingJob;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NlpLearningRateSchedulerConstant
{
    [Description("Constant")]
    Constant,

    [Description("ConstantWithWarmup")]
    ConstantWithWarmup,

    [Description("Cosine")]
    Cosine,

    [Description("CosineWithRestarts")]
    CosineWithRestarts,

    [Description("Linear")]
    Linear,

    [Description("None")]
    None,

    [Description("Polynomial")]
    Polynomial,
}
