// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryImageVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Replicating")]
    Replicating,

    [Description("Unknown")]
    Unknown,
}
