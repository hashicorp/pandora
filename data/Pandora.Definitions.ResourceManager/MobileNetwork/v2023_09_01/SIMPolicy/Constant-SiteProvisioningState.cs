// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.SIMPolicy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SiteProvisioningStateConstant
{
    [Description("Adding")]
    Adding,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("Provisioned")]
    Provisioned,

    [Description("Updating")]
    Updating,
}
