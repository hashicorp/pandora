// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrintJobStateDetailConstant
{
    [Description("UploadPending")]
    @uploadPending,

    [Description("Transforming")]
    @transforming,

    [Description("CompletedSuccessfully")]
    @completedSuccessfully,

    [Description("CompletedWithWarnings")]
    @completedWithWarnings,

    [Description("CompletedWithErrors")]
    @completedWithErrors,

    [Description("ReleaseWait")]
    @releaseWait,

    [Description("Interpreting")]
    @interpreting,
}
