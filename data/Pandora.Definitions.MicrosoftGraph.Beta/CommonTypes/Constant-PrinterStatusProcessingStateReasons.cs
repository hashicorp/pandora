// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrinterStatusProcessingStateReasonsConstant
{
    [Description("Paused")]
    @paused,

    [Description("MediaJam")]
    @mediaJam,

    [Description("MediaNeeded")]
    @mediaNeeded,

    [Description("MediaLow")]
    @mediaLow,

    [Description("MediaEmpty")]
    @mediaEmpty,

    [Description("CoverOpen")]
    @coverOpen,

    [Description("InterlockOpen")]
    @interlockOpen,

    [Description("OutputTrayMissing")]
    @outputTrayMissing,

    [Description("OutputAreaFull")]
    @outputAreaFull,

    [Description("MarkerSupplyLow")]
    @markerSupplyLow,

    [Description("MarkerSupplyEmpty")]
    @markerSupplyEmpty,

    [Description("InputTrayMissing")]
    @inputTrayMissing,

    [Description("OutputAreaAlmostFull")]
    @outputAreaAlmostFull,

    [Description("MarkerWasteAlmostFull")]
    @markerWasteAlmostFull,

    [Description("MarkerWasteFull")]
    @markerWasteFull,

    [Description("FuserOverTemp")]
    @fuserOverTemp,

    [Description("FuserUnderTemp")]
    @fuserUnderTemp,

    [Description("Other")]
    @other,

    [Description("None")]
    @none,

    [Description("MovingToPaused")]
    @movingToPaused,

    [Description("Shutdown")]
    @shutdown,

    [Description("ConnectingToDevice")]
    @connectingToDevice,

    [Description("TimedOut")]
    @timedOut,

    [Description("Stopping")]
    @stopping,

    [Description("StoppedPartially")]
    @stoppedPartially,

    [Description("TonerLow")]
    @tonerLow,

    [Description("TonerEmpty")]
    @tonerEmpty,

    [Description("SpoolAreaFull")]
    @spoolAreaFull,

    [Description("DoorOpen")]
    @doorOpen,

    [Description("OpticalPhotoConductorNearEndOfLife")]
    @opticalPhotoConductorNearEndOfLife,

    [Description("OpticalPhotoConductorLifeOver")]
    @opticalPhotoConductorLifeOver,

    [Description("DeveloperLow")]
    @developerLow,

    [Description("DeveloperEmpty")]
    @developerEmpty,

    [Description("InterpreterResourceUnavailable")]
    @interpreterResourceUnavailable,
}
