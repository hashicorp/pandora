// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.PrivateLinkResources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupIdProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
