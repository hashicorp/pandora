// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_07_01.CredentialSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialNameConstant
{
    [Description("Credential1")]
    CredentialOne,
}
