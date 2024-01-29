// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskStateConstant
{
    [Description("ActiveSAS")]
    ActiveSAS,

    [Description("ActiveSASFrozen")]
    ActiveSASFrozen,

    [Description("ActiveUpload")]
    ActiveUpload,

    [Description("Attached")]
    Attached,

    [Description("Frozen")]
    Frozen,

    [Description("ReadyToUpload")]
    ReadyToUpload,

    [Description("Reserved")]
    Reserved,

    [Description("Unattached")]
    Unattached,
}
