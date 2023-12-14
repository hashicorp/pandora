// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityGovernanceTaskReportProcessingStatusConstant
{
    [Description("Queued")]
    @queued,

    [Description("InProgress")]
    @inProgress,

    [Description("Completed")]
    @completed,

    [Description("CompletedWithErrors")]
    @completedWithErrors,

    [Description("Canceled")]
    @canceled,

    [Description("Failed")]
    @failed,
}
