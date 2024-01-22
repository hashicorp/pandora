// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeCreateOptionConstant
{
    [Description("None")]
    None,
}
