// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.ServerEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerEndpointSyncModeConstant
{
    [Description("InitialFullDownload")]
    InitialFullDownload,

    [Description("InitialUpload")]
    InitialUpload,

    [Description("NamespaceDownload")]
    NamespaceDownload,

    [Description("Regular")]
    Regular,

    [Description("SnapshotUpload")]
    SnapshotUpload,
}
