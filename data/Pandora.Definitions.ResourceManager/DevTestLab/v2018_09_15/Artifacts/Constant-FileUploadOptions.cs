// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Artifacts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileUploadOptionsConstant
{
    [Description("None")]
    None,

    [Description("UploadFilesAndGenerateSasTokens")]
    UploadFilesAndGenerateSasTokens,
}
