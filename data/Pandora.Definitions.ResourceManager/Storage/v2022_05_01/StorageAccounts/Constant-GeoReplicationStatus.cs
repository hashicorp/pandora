// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoReplicationStatusConstant
{
    [Description("Bootstrap")]
    Bootstrap,

    [Description("Live")]
    Live,

    [Description("Unavailable")]
    Unavailable,
}
