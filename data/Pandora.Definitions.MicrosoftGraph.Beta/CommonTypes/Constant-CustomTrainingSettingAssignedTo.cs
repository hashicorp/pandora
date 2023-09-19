// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomTrainingSettingAssignedToConstant
{
    [Description("None")]
    @none,

    [Description("AllUsers")]
    @allUsers,

    [Description("ClickedPayload")]
    @clickedPayload,

    [Description("Compromised")]
    @compromised,

    [Description("ReportedPhish")]
    @reportedPhish,

    [Description("ReadButNotClicked")]
    @readButNotClicked,

    [Description("DidNothing")]
    @didNothing,
}
