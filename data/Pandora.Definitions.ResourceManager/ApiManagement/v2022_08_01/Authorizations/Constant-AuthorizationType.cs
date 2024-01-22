// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Authorizations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthorizationTypeConstant
{
    [Description("OAuth2")]
    OAuthTwo,
}
