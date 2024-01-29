// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeDefinitionTypeConstant
{
    [Description("bind")]
    Bind,

    [Description("npipe")]
    Npipe,

    [Description("tmpfs")]
    Tmpfs,

    [Description("volume")]
    Volume,
}
