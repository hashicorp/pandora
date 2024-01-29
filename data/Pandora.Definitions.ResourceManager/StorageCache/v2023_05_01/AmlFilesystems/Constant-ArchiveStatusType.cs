// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArchiveStatusTypeConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Cancelling")]
    Cancelling,

    [Description("Completed")]
    Completed,

    [Description("FSScanInProgress")]
    FSScanInProgress,

    [Description("Failed")]
    Failed,

    [Description("Idle")]
    Idle,

    [Description("InProgress")]
    InProgress,

    [Description("NotConfigured")]
    NotConfigured,
}
