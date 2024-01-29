// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AllowedCopyScopeConstant
{
    [Description("AAD")]
    AAD,

    [Description("PrivateLink")]
    PrivateLink,
}
