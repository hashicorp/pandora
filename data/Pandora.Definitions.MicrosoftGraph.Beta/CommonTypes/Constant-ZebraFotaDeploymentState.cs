// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ZebraFotaDeploymentStateConstant
{
    [Description("PendingCreation")]
    @pendingCreation,

    [Description("CreateFailed")]
    @createFailed,

    [Description("Created")]
    @created,

    [Description("InProgress")]
    @inProgress,

    [Description("Completed")]
    @completed,

    [Description("PendingCancel")]
    @pendingCancel,

    [Description("Canceled")]
    @canceled,
}
