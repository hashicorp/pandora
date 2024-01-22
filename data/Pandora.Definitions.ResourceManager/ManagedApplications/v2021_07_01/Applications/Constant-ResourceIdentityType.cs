// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceIdentityTypeConstant
{
    [Description("None")]
    None,

    [Description("SystemAssigned")]
    SystemAssigned,

    [Description("SystemAssigned, UserAssigned")]
    SystemAssignedUserAssigned,

    [Description("UserAssigned")]
    UserAssigned,
}
