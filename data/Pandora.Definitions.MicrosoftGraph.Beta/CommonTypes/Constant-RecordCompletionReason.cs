// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecordCompletionReasonConstant
{
    [Description("OperationCanceled")]
    @operationCanceled,

    [Description("StopToneDetected")]
    @stopToneDetected,

    [Description("MaxRecordDurationReached")]
    @maxRecordDurationReached,

    [Description("InitialSilenceTimeout")]
    @initialSilenceTimeout,

    [Description("MaxSilenceTimeout")]
    @maxSilenceTimeout,

    [Description("PlayPromptFailed")]
    @playPromptFailed,

    [Description("PlayBeepFailed")]
    @playBeepFailed,

    [Description("MediaReceiveTimeout")]
    @mediaReceiveTimeout,

    [Description("UnspecifiedError")]
    @unspecifiedError,
}
