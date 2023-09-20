// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecordingInfoRecordingStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("NotRecording")]
    @notRecording,

    [Description("Recording")]
    @recording,

    [Description("Failed")]
    @failed,
}
