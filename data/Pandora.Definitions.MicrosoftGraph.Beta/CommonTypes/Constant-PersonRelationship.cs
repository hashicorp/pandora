// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PersonRelationshipConstant
{
    [Description("Manager")]
    @manager,

    [Description("Colleague")]
    @colleague,

    [Description("DirectReport")]
    @directReport,

    [Description("DotLineReport")]
    @dotLineReport,

    [Description("Assistant")]
    @assistant,

    [Description("DotLineManager")]
    @dotLineManager,

    [Description("AlternateContact")]
    @alternateContact,

    [Description("Friend")]
    @friend,

    [Description("Spouse")]
    @spouse,

    [Description("Sibling")]
    @sibling,

    [Description("Child")]
    @child,

    [Description("Parent")]
    @parent,

    [Description("Sponsor")]
    @sponsor,

    [Description("EmergencyContact")]
    @emergencyContact,

    [Description("Other")]
    @other,
}
