// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobInputTypeConstant
{
    [Description("custom_model")]
    CustomModel,

    [Description("literal")]
    Literal,

    [Description("mlflow_model")]
    MlflowModel,

    [Description("mltable")]
    Mltable,

    [Description("triton_model")]
    TritonModel,

    [Description("uri_file")]
    UriFile,

    [Description("uri_folder")]
    UriFolder,
}
