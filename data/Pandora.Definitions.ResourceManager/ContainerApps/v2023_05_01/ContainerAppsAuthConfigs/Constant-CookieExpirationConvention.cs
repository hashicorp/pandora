// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerAppsAuthConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CookieExpirationConventionConstant
{
    [Description("FixedTime")]
    FixedTime,

    [Description("IdentityProviderDerived")]
    IdentityProviderDerived,
}
