// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LobbyBypassSettingsScopeConstant
{
    [Description("Organizer")]
    @organizer,

    [Description("Organization")]
    @organization,

    [Description("OrganizationAndFederated")]
    @organizationAndFederated,

    [Description("Everyone")]
    @everyone,

    [Description("Invited")]
    @invited,

    [Description("OrganizationExcludingGuests")]
    @organizationExcludingGuests,
}
