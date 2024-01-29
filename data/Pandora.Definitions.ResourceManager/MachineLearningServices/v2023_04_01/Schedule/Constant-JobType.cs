// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTypeConstant
{
    [Description("AutoML")]
    AutoML,

    [Description("Command")]
    Command,

    [Description("Pipeline")]
    Pipeline,

    [Description("Sweep")]
    Sweep,
}
