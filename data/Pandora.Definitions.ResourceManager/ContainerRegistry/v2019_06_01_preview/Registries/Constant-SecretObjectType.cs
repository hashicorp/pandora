// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecretObjectTypeConstant
{
    [Description("Opaque")]
    Opaque,

    [Description("Vaultsecret")]
    Vaultsecret,
}
