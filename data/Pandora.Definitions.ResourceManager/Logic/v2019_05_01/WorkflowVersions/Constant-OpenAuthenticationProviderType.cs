// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OpenAuthenticationProviderTypeConstant
{
    [Description("AAD")]
    AAD,
}
