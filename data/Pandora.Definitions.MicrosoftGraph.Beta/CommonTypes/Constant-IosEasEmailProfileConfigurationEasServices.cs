// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosEasEmailProfileConfigurationEasServicesConstant
{
    [Description("None")]
    @none,

    [Description("Calendars")]
    @calendars,

    [Description("Contacts")]
    @contacts,

    [Description("Email")]
    @email,

    [Description("Notes")]
    @notes,

    [Description("Reminders")]
    @reminders,
}
