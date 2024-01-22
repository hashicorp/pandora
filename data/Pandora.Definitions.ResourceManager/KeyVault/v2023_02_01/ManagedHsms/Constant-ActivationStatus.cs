// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActivationStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Failed")]
    Failed,

    [Description("NotActivated")]
    NotActivated,

    [Description("Unknown")]
    Unknown,
}
