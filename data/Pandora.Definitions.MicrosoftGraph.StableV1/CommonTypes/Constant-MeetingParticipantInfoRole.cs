// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MeetingParticipantInfoRoleConstant
{
    [Description("Attendee")]
    @attendee,

    [Description("Presenter")]
    @presenter,

    [Description("Producer")]
    @producer,

    [Description("Coorganizer")]
    @coorganizer,
}
