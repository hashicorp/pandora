// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerEndpointSyncHealthStateConstant
{
    [Description("Error")]
    Error,

    [Description("Healthy")]
    Healthy,

    [Description("NoActivity")]
    NoActivity,

    [Description("SyncBlockedForChangeDetectionPostRestore")]
    SyncBlockedForChangeDetectionPostRestore,

    [Description("SyncBlockedForRestore")]
    SyncBlockedForRestore,
}
