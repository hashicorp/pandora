// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.Disks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskCreateOptionConstant
{
    [Description("Attach")]
    Attach,

    [Description("Copy")]
    Copy,

    [Description("CopyFromSanSnapshot")]
    CopyFromSanSnapshot,

    [Description("CopyStart")]
    CopyStart,

    [Description("Empty")]
    Empty,

    [Description("FromImage")]
    FromImage,

    [Description("Import")]
    Import,

    [Description("ImportSecure")]
    ImportSecure,

    [Description("Restore")]
    Restore,

    [Description("Upload")]
    Upload,

    [Description("UploadPreparedSecure")]
    UploadPreparedSecure,
}
