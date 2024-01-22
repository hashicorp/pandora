// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.RecoveryPoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SQLDataDirectoryTypeConstant
{
    [Description("Data")]
    Data,

    [Description("Invalid")]
    Invalid,

    [Description("Log")]
    Log,
}
