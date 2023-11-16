// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEdiscoverySearchExportOperationStatusConstant
{
    [Description("NotStarted")]
    @notStarted,

    [Description("SubmissionFailed")]
    @submissionFailed,

    [Description("Running")]
    @running,

    [Description("Succeeded")]
    @succeeded,

    [Description("PartiallySucceeded")]
    @partiallySucceeded,

    [Description("Failed")]
    @failed,
}
