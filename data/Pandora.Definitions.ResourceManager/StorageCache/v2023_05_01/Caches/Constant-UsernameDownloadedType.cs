// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.Caches;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsernameDownloadedTypeConstant
{
    [Description("Error")]
    Error,

    [Description("No")]
    No,

    [Description("Yes")]
    Yes,
}
