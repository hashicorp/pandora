// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.BatchEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointAuthModeConstant
{
    [Description("AADToken")]
    AADToken,

    [Description("AMLToken")]
    AMLToken,

    [Description("Key")]
    Key,
}
