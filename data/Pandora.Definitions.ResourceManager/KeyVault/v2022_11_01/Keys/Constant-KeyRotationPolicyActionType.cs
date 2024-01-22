// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Keys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyRotationPolicyActionTypeConstant
{
    [Description("Notify")]
    Notify,

    [Description("Rotate")]
    Rotate,
}
