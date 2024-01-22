// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_07_01.ManagedHsmKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyOperationConstant
{
    [Description("decrypt")]
    Decrypt,

    [Description("encrypt")]
    Encrypt,

    [Description("import")]
    Import,

    [Description("release")]
    Release,

    [Description("sign")]
    Sign,

    [Description("unwrapKey")]
    UnwrapKey,

    [Description("verify")]
    Verify,

    [Description("wrapKey")]
    WrapKey,
}
