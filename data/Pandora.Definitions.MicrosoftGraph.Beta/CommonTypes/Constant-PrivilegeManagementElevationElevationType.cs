// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivilegeManagementElevationElevationTypeConstant
{
    [Description("Undetermined")]
    @undetermined,

    [Description("UnmanagedElevation")]
    @unmanagedElevation,

    [Description("ZeroTouchElevation")]
    @zeroTouchElevation,

    [Description("UserConfirmedElevation")]
    @userConfirmedElevation,

    [Description("SupportApprovedElevation")]
    @supportApprovedElevation,
}
