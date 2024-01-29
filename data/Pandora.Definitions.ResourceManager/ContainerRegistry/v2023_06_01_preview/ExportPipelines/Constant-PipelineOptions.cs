// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.ExportPipelines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PipelineOptionsConstant
{
    [Description("ContinueOnErrors")]
    ContinueOnErrors,

    [Description("DeleteSourceBlobOnSuccess")]
    DeleteSourceBlobOnSuccess,

    [Description("OverwriteBlobs")]
    OverwriteBlobs,

    [Description("OverwriteTags")]
    OverwriteTags,
}
