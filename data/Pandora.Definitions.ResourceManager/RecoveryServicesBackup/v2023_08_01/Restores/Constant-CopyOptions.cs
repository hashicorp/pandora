// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.Restores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CopyOptionsConstant
{
    [Description("CreateCopy")]
    CreateCopy,

    [Description("FailOnConflict")]
    FailOnConflict,

    [Description("Invalid")]
    Invalid,

    [Description("Overwrite")]
    Overwrite,

    [Description("Skip")]
    Skip,
}
