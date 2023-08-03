// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsAutopilotProfileAssignmentStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("AssignedInSync")]
    @assignedInSync,

    [Description("AssignedOutOfSync")]
    @assignedOutOfSync,

    [Description("AssignedUnkownSyncState")]
    @assignedUnkownSyncState,

    [Description("NotAssigned")]
    @notAssigned,

    [Description("Pending")]
    @pending,

    [Description("Failed")]
    @failed,
}
