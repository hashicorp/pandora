// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupProtectableItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InquiryStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Success")]
    Success,
}
