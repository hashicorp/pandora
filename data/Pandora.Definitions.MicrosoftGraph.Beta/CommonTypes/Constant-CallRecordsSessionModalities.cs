// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallRecordsSessionModalitiesConstant
{
    [Description("Audio")]
    @audio,

    [Description("Video")]
    @video,

    [Description("VideoBasedScreenSharing")]
    @videoBasedScreenSharing,

    [Description("Data")]
    @data,

    [Description("ScreenSharing")]
    @screenSharing,
}
