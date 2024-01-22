// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DistributionTypeConstant
{
    [Description("Mpi")]
    Mpi,

    [Description("PyTorch")]
    PyTorch,

    [Description("Ray")]
    Ray,

    [Description("TensorFlow")]
    TensorFlow,
}
