// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.DataMove;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataMoveLevelConstant
{
    [Description("Container")]
    Container,

    [Description("Invalid")]
    Invalid,

    [Description("Vault")]
    Vault,
}
