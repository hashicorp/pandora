// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.VolumeGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTargetTypeConstant
{
    [Description("Iscsi")]
    Iscsi,

    [Description("None")]
    None,
}
