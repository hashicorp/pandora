// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.ProtectionIntent;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Succeeded")]
    Succeeded,
}
