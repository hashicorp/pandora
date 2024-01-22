// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Authorization;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OAuth2GrantTypeConstant
{
    [Description("AuthorizationCode")]
    AuthorizationCode,

    [Description("ClientCredentials")]
    ClientCredentials,
}
