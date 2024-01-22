// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.AuthorizationServer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClientAuthenticationMethodConstant
{
    [Description("Basic")]
    Basic,

    [Description("Body")]
    Body,
}
