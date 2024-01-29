// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VideoAnalyzerEndpointTypeConstant
{
    [Description("ClientApi")]
    ClientApi,
}
