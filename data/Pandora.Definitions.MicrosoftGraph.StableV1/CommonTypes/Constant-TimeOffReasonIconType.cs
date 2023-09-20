// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeOffReasonIconTypeConstant
{
    [Description("None")]
    @none,

    [Description("Car")]
    @car,

    [Description("Calendar")]
    @calendar,

    [Description("Running")]
    @running,

    [Description("Plane")]
    @plane,

    [Description("FirstAid")]
    @firstAid,

    [Description("Doctor")]
    @doctor,

    [Description("NotWorking")]
    @notWorking,

    [Description("Clock")]
    @clock,

    [Description("JuryDuty")]
    @juryDuty,

    [Description("Globe")]
    @globe,

    [Description("Cup")]
    @cup,

    [Description("Phone")]
    @phone,

    [Description("Weather")]
    @weather,

    [Description("Umbrella")]
    @umbrella,

    [Description("PiggyBank")]
    @piggyBank,

    [Description("Dog")]
    @dog,

    [Description("Cake")]
    @cake,

    [Description("TrafficCone")]
    @trafficCone,

    [Description("Pin")]
    @pin,

    [Description("Sunny")]
    @sunny,
}
