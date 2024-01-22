// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2023_11_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateLinkServiceConnectionProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Incomplete")]
    Incomplete,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
