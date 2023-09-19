// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Win32LobAppAssignmentSettingsNotificationsConstant
{
    [Description("ShowAll")]
    @showAll,

    [Description("ShowReboot")]
    @showReboot,

    [Description("HideAll")]
    @hideAll,
}
