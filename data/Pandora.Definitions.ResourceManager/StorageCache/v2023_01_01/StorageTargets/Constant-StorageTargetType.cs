// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.StorageTargets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTargetTypeConstant
{
    [Description("blobNfs")]
    BlobNfs,

    [Description("clfs")]
    Clfs,

    [Description("nfs3")]
    NfsThree,

    [Description("unknown")]
    Unknown,
}
