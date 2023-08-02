// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceAppManagementTaskStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Pending")]
    @pending,

    [Description("Active")]
    @active,

    [Description("Completed")]
    @completed,

    [Description("Rejected")]
    @rejected,
}
