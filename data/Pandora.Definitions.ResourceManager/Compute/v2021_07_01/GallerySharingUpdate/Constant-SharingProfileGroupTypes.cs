// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GallerySharingUpdate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharingProfileGroupTypesConstant
{
    [Description("AADTenants")]
    AADTenants,

    [Description("Subscriptions")]
    Subscriptions,
}
