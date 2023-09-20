// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PersonAwardAllowedAudiencesConstant
{
    [Description("Me")]
    @me,

    [Description("Family")]
    @family,

    [Description("Contacts")]
    @contacts,

    [Description("GroupMembers")]
    @groupMembers,

    [Description("Organization")]
    @organization,

    [Description("FederatedOrganizations")]
    @federatedOrganizations,

    [Description("Everyone")]
    @everyone,
}
