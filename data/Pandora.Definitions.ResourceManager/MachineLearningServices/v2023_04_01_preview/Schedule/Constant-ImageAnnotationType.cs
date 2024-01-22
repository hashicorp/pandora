// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImageAnnotationTypeConstant
{
    [Description("BoundingBox")]
    BoundingBox,

    [Description("Classification")]
    Classification,

    [Description("InstanceSegmentation")]
    InstanceSegmentation,
}
