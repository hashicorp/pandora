// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Workflows;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OpenAuthenticationProviderTypeConstant
{
    [Description("AAD")]
    AAD,
}
