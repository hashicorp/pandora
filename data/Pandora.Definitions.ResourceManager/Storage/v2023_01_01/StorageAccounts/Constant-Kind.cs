// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("BlobStorage")]
    BlobStorage,

    [Description("BlockBlobStorage")]
    BlockBlobStorage,

    [Description("FileStorage")]
    FileStorage,

    [Description("Storage")]
    Storage,

    [Description("StorageV2")]
    StorageVTwo,
}
