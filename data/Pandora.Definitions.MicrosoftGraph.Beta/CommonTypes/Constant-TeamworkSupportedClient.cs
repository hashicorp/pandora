// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamworkSupportedClientConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("SkypeDefaultAndTeams")]
    @skypeDefaultAndTeams,

    [Description("TeamsDefaultAndSkype")]
    @teamsDefaultAndSkype,

    [Description("SkypeOnly")]
    @skypeOnly,

    [Description("TeamsOnly")]
    @teamsOnly,
}
