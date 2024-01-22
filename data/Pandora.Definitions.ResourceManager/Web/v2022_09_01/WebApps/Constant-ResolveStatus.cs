// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResolveStatusConstant
{
    [Description("AccessToKeyVaultDenied")]
    AccessToKeyVaultDenied,

    [Description("FetchTimedOut")]
    FetchTimedOut,

    [Description("Initialized")]
    Initialized,

    [Description("InvalidSyntax")]
    InvalidSyntax,

    [Description("MSINotEnabled")]
    MSINotEnabled,

    [Description("OtherReasons")]
    OtherReasons,

    [Description("Resolved")]
    Resolved,

    [Description("SecretNotFound")]
    SecretNotFound,

    [Description("SecretVersionNotFound")]
    SecretVersionNotFound,

    [Description("UnauthorizedClient")]
    UnauthorizedClient,

    [Description("VaultNotFound")]
    VaultNotFound,
}
