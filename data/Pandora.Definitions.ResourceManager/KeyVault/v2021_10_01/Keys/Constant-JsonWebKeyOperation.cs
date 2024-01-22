// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Keys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyOperationConstant
{
    [Description("decrypt")]
    Decrypt,

    [Description("encrypt")]
    Encrypt,

    [Description("import")]
    Import,

    [Description("sign")]
    Sign,

    [Description("unwrapKey")]
    UnwrapKey,

    [Description("verify")]
    Verify,

    [Description("wrapKey")]
    WrapKey,
}
