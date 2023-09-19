// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventMessageResponseResponseTypeConstant
{
    [Description("None")]
    @none,

    [Description("Organizer")]
    @organizer,

    [Description("TentativelyAccepted")]
    @tentativelyAccepted,

    [Description("Accepted")]
    @accepted,

    [Description("Declined")]
    @declined,

    [Description("NotResponded")]
    @notResponded,
}
